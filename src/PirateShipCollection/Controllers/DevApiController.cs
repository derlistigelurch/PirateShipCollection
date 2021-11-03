using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<DevLogic> _logger;

        public DevApiController(IDevLogic devLogic, ILogger<DevLogic> logger)
        {
            _devLogic = devLogic;
            _logger = logger;
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
            try
            {
                _devLogic.FillDatabase();
                return new OkResult();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
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
            try
            {
                _devLogic.DeleteDatabase();
                return new OkResult();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
        }
    }
}