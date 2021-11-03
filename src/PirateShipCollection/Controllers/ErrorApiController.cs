using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PirateShipCollection.Models;

namespace PirateShipCollection.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorApiController : ControllerBase
    {
        /// <summary>
        /// Catches exception of TopLayer and calls Error to build final exception message
        /// </summary>
        /// <returns>error model</returns>
        [Route("ErrorDev")]
        public ErrorResponse ErrorDevelopment()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return new ErrorResponse
            {
                Type = context.Error.GetType().Name,
                Message = context.Error.Message,
                StackTrace = context.Error.ToString(),
            };
        }

        /// <summary>
        /// Catches exception of TopLayer and calls Error to build final exception message
        /// </summary>
        /// <returns>error model</returns>
        [Route("Error")]
        public ErrorResponse ErrorProduction()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return new ErrorResponse()
            {
                Type = context.Error.GetType().Name,
                Message = context.Error.Message,
            };
        }
    }
}