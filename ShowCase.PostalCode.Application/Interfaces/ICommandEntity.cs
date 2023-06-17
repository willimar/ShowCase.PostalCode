using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.PostalCode.Application.Interfaces
{
    public interface ICommandEntity
    {
        public Guid? Id { get; set; }
    }
}
