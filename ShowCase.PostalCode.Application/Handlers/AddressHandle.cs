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
    public class AddressHandle : BaseHandle<Address, AddressCommand>, IRequestHandler<AddressCommand, IResponseMessage>
    {
        public AddressHandle(IUser user, IRepository<Address> repository, IValidator<Address>? validator, IMapperProfile<AddressCommand, Address> mapperProfile) : base(user, repository, validator, mapperProfile)
        {
        }
    }
}
