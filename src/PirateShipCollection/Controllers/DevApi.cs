using System;
using Microsoft.AspNetCore.Mvc;
using PirateShipCollection.Attributes;
using PirateShipCollection.Logic;
using PirateShipCollection.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace PirateShipCollection.Controllers
{
    [ApiController]
    public class DevApiController : ControllerBase
    {
        private readonly IDevLogic _devLogic;
        private readonly BadRequestObjectResult _badRequestResult;
        private readonly OkObjectResult _okRequestResult;

        public DevApiController(IDevLogic devLogic)
        {
            _devLogic = devLogic;
            _badRequestResult = new BadRequestObjectResult(
                new ApiResponse
                {
                    Code = 400,
                    Message = "Uuuuups.... something went wrong :D",
                    Type = "Error"
                });
            _okRequestResult = new OkObjectResult(
                new ApiResponse
                {
                    Code = 200,
                    Message = "Operation successfull",
                    Type = "Success"
                });
        }

        /// <summary>
        /// Fills the database with test data
        /// </summary>
        /// <response code="200">Operation successfull</response>
        /// <response code="400">Something went wrong</response>
        [HttpPost]
        [Route("/v2/dev")]
        [ValidateModelState]
        [SwaggerOperation("FillDatabase")]
        public virtual IActionResult FillDatabase()
        {
            return _devLogic.FillDatabase() > 0
                ? _okRequestResult
                : _badRequestResult;
        }

        /// <summary>
        /// Deletes the database
        /// </summary>
        /// <response code="200">Operation successfull</response>
        /// <response code="400">Something went wrong</response>
        [HttpGet]
        [Route("/v2/dev")]
        [ValidateModelState]
        [SwaggerOperation("ResetDatabase")]
        public virtual IActionResult ResetDatabase()
        {
            _devLogic.DeleteDatabase();
            return new OkResult();
        }
    }
}