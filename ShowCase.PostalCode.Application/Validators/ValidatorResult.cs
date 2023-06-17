using DataCore.Domain.Enumerators;
using DataCore.Domain.Interfaces;

namespace ShowCase.PostalCode.Application.Validators
{
    internal class ValidatorResult : IValidatorResult
    {
        private HandlesCode[] _validHandlesCodes = new HandlesCode[] { HandlesCode.Accepted, HandlesCode.Ok };

        public bool IsValid => !Messages.Any() || Messages.Any(x => _validHandlesCodes.Any(y => y == x.Code));

        public IEnumerable<IHandleMessage> Messages { get; }

        public ValidatorResult(IEnumerable<IHandleMessage> messages)
        {
            Messages = messages;
        }
    }
}
