using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShowCase.PostalCode.Application.Commands;

namespace ShowCase.PostalCode.Controllers.v2
{
    [ApiExplorerSettings(GroupName = "Postal Code")]
    public class StateController : BaseController
    {
        public StateController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// A person's register can insert and change records in the database.
        /// </summary>
        [HttpPost("save-person")]
        public async ValueTask<IActionResult> Post([FromBody] StateCommand command)
        {
            var response = await this._mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
