using DataCore.Domain.Concrets;
using DataCore.Domain.Enumerators;
using DataCore.Domain.Interfaces;
using DataCore.Mapper;
using ShowCase.PostalCode.Application.Concrets;
using ShowCase.PostalCode.Application.Interfaces;
using ShowCase.PostalCode.Application.Properties;

namespace ShowCase.PostalCode.Application.Handlers
{
    public delegate Task OnBeforeDelegate<TEntity, TCommand>(TEntity entity, TCommand command)
            where TEntity : class, IEntity
            where TCommand : class, ICommandEntity;

    public delegate Task OnBeforeResponse(IResponseMessage response);

    public abstract class BaseHandle<TEntity, TCommand>
        where TEntity : class, IEntity
        where TCommand : class, ICommandEntity
    {
        protected readonly IUser _user;

        private readonly IRepository<TEntity> _repository;
        private readonly IValidator<TEntity>? _validator;
        private readonly IMapperProfile<TCommand, TEntity> _mapperProfile;

        protected event OnBeforeDelegate<TEntity, TCommand>? OnBeforeInsert;
        protected event OnBeforeDelegate<TEntity, TCommand>? OnBeforeUpdate;
        protected event OnBeforeDelegate<TEntity, TCommand>? OnBeforeApplyChanges;
        protected event OnBeforeResponse? OnBeforeResponse;

        public BaseHandle(IUser user, IRepository<TEntity> repository, IValidator<TEntity>? validator, IMapperProfile<TCommand, TEntity> mapperProfile)
        {
            this._user = user;
            this._repository = repository;
            this._validator = validator;
            this._mapperProfile = mapperProfile;
        }

        public virtual async Task<IResponseMessage> Handle(TCommand command, CancellationToken cancellationToken)

        {
            List<IHandleMessage> handleMessages = new();
            TEntity? entity;
            IResponseMessage responseMessage;

            if (IsNewRecord(command))
            {
                entity = _mapperProfile.Map(command);

                if (OnBeforeInsert is not null)
                {
                    await OnBeforeInsert(entity, command);
                }

                var response = await this._repository.AppenData(entity, this._validator, cancellationToken);

                handleMessages.AddRange(response);
            }
            else
            {
                entity = this._repository.GetData(x => x.Id == command.Id).FirstOrDefault();

                if (entity is null)
                {
                    var message = HandleMessage.Factory(typeof(KeyNotFoundException), Resources.KeyNotFoundException, HandlesCode.ValueNotFound);

                    handleMessages.Add(message);

                    responseMessage = new ResponseMessage(handleMessages);

                    await ExecuteBeforeResponse(responseMessage);
                    return responseMessage;
                }

                _ = _mapperProfile.Map(command, entity);

                if (OnBeforeUpdate is not null)
                {
                    await OnBeforeUpdate(entity, command);
                }

                var response = await this._repository.UpdateData(entity, this._validator, cancellationToken);

                handleMessages.AddRange(response);
            }

            var saved = await this._repository.ContextApplyChanges(cancellationToken);

            if (!saved)
            {
                var message = HandleMessage.Factory("DataBaseException", Resources.DataBaseException, HandlesCode.InternalException);

                handleMessages.Add(message);

                responseMessage = new ResponseMessage(handleMessages);

                await ExecuteBeforeResponse(responseMessage);
                return responseMessage;
            }

            responseMessage = new ResponseMessage(handleMessages);

            await ExecuteBeforeResponse(responseMessage);
            return responseMessage;
        }

        
        private async Task ExecuteBeforeResponse(IResponseMessage response)
        {
            if (OnBeforeResponse is not null)
            {
                await OnBeforeResponse(response);
            }
        }

        private static bool IsNewRecord(ICommandEntity commandEntity)
        {
            var isNewRecord = commandEntity.Id is null || commandEntity.Id == Guid.Empty;

            return isNewRecord;
        }
    }
}
