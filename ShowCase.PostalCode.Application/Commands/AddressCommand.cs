using MediatR;
using ShowCase.PostalCode.Application.Interfaces;

namespace ShowCase.PostalCode.Application.Commands
{
    public class AddressCommand : IRequest<IResponseMessage>, ICommandEntity
    {
        public Guid? Id { get; set; }
    }
}
