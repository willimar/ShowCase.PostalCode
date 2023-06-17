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
    public class CityHandle : BaseHandle<City, CityCommand>, IRequestHandler<CityCommand, IResponseMessage>
    {
        public CityHandle(IUser user, IRepository<City> repository, IValidator<City>? validator, IMapperProfile<CityCommand, City> mapperProfile) : base(user, repository, validator, mapperProfile)
        {
        }
    }
}
