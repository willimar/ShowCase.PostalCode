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
    public class CountryMapper : MapperProfile<CountryCommand, Country>
    {
        protected override void ForMemberMapper(IMappingExpression<CountryCommand, Country> mapping)
        {
            throw new NotImplementedException();
        }
    }
}
