using DataCore.Domain.Interfaces;
using DataCore.Mapper;
using MediatR;
using ShowCase.PostalCode.Application.Commands;
using ShowCase.PostalCode.Application.Entities;
using ShowCase.PostalCode.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.PostalCode.Application.Handlers
{
    public class StateHandle : BaseHandle<State, StateCommand>, IRequestHandler<StateCommand, IResponseMessage>
    {
        public StateHandle(IUser user, IRepository<State> repository, IValidator<State>? validator, IMapperProfile<StateCommand, State> mapperProfile) : base(user, repository, validator, mapperProfile)
        {
        }
    }
}
