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
    public class CoutryHandle : BaseHandle<Country, CountryCommand>, IRequestHandler<CountryCommand, IResponseMessage>
    {
        public CoutryHandle(IUser user, IRepository<Country> repository, IValidator<Country>? validator, IMapperProfile<CountryCommand, Country> mapperProfile) : base(user, repository, validator, mapperProfile)
        {
        }
    }
}
