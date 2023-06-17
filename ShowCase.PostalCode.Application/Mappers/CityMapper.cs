using AutoMapper;
using DataCore.Mapper;
using ShowCase.PostalCode.Application.Commands;
using ShowCase.PostalCode.Application.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.PostalCode.Application.Mappers
{
    public class CityMapper : MapperProfile<CityCommand, City>
    {
        protected override void ForMemberMapper(IMappingExpression<CityCommand, City> mapping)
        {
            throw new NotImplementedException();
        }
    }
}
