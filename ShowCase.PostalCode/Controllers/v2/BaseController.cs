using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ShowCase.PostalCode.Controllers.v2
{
    [EnableCors(SwaggerSetup.AllowAnyOrigins)]
    [ApiVersion("2", Deprecated = false)]
    [ApiController]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/[controller]/")]
    [IgnoreAntiforgeryToken(Order = 1001)]
    [Authorize]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
