using DataCore.Domain.Enumerators;
using DataCore.Domain.Interfaces;
using ShowCase.PostalCode.Application.Interfaces;

namespace ShowCase.PostalCode.Application.Concrets
{
    internal class ResponseMessage : IResponseMessage
    {
        private readonly HandlesCode[] _validHandlesCodes = new HandlesCode[] { HandlesCode.Accepted, HandlesCode.Ok };

        public HandlesCode StatusCode => this.GetStatusCode();

        public bool IsSuccessStatusCode => !Messages.Any() || Messages.Any(x => _validHandlesCodes.Any(y => y == x.Code));

        public IEnumerable<IHandleMessage> Messages { get; set; } = new List<IHandleMessage>();

        public ResponseMessage(List<IHandleMessage> messages)
        {
            Messages = messages;
        }

        private HandlesCode GetStatusCode()
        {
            var badCode = Messages.Where(x => !_validHandlesCodes.Any(y => y == x.Code)).OrderByDescending(x => x.Code).FirstOrDefault();

            if (badCode is not null)
            {
                return badCode.Code;
            }

            var funCode = Messages.Where(x => _validHandlesCodes.Any(y => y == x.Code)).OrderBy(x => x.Code).FirstOrDefault();

            if (funCode is not null)
            {
                return funCode.Code;
            }

            return HandlesCode.Accepted;
        }
    }
}
