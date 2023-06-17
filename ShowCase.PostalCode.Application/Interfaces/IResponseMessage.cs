using DataCore.Domain.Enumerators;
using DataCore.Domain.Interfaces;

namespace ShowCase.PostalCode.Application.Interfaces
{
    public interface IResponseMessage
    {
        public HandlesCode StatusCode { get; }
        public bool IsSuccessStatusCode { get; }
        public IEnumerable<IHandleMessage> Messages { get; set; }
    }
}
