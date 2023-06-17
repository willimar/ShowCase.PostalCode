using DataCore.Domain.Concrets;
using DataCore.Domain.Enumerators;
using DataCore.Domain.Interfaces;
using FluentValidation;
using ShowCase.PostalCode.Application.Entities;
using ShowCase.PostalCode.Application.Interfaces;
using ShowCase.PostalCode.Application.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.PostalCode.Application.Validators
{
    public class AddressValidator : DataCore.Domain.Interfaces.IValidator<Address>, IAppValidator
    {
        internal class InternalValidator : AbstractValidator<Address>
        {
            private InternalValidator()
            {

            }

            public static IEnumerable<IHandleMessage> GetHandles(Address entity)
            {
                var validator = new InternalValidator();
                var validatorResponse = validator.Validate(entity);
                var response = new List<IHandleMessage>();

                if (validatorResponse is null)
                {
                    return response;
                }

                validatorResponse.Errors.ForEach(error => { response.Add(HandleMessage.Factory(error.PropertyName, error.ErrorMessage, HandlesCode.BadRequest)); });

                return response;
            }
        }

        public async ValueTask<IValidatorResult> Validate(Address entity, CancellationToken cancellationToken)
        {
            var messages = InternalValidator.GetHandles(entity);
            var response = new ValidatorResult(messages);

            return await Task.FromResult(response);
        }
    }
}
