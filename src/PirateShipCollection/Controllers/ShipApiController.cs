using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PirateShipCollection.Attributes;
using PirateShipCollection.Logic;
using PirateShipCollection.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace PirateShipCollection.Controllers
{
    [ApiController]
    public class ShipApiController : ControllerBase
    {
        private readonly IShipLogic _shipLogic;
        private readonly ILogger<ShipApiController> _logger;

        public ShipApiController(IShipLogic shipLogic, ILogger<ShipApiController> logger)
        {
            _shipLogic = shipLogic;
            _logger = logger;
        }

        /// <summary>
        /// Add a new ship to the store
        /// </summary>
        /// <param name="body">Ship object that needs to be added to the collection</param>
        /// <response code="200">Operation successfull</response>
        /// <response code="400">Something went wrong</response>
        [HttpPost]
        [Route("/v2/ship")]
        [ValidateModelState]
        [SwaggerOperation("AddShip")]
        public virtual IActionResult AddShip([FromBody] Ship body)
        {
            try
            {
                _shipLogic.CreateShip(body);
                return new OkResult();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Deletes a ship
        /// </summary>
        /// <param name="shipId">Ship id to delete</param>
        /// <response code="200">Operation successfull</response>
        /// <response code="400">Something went wrong</response>
        [HttpDelete]
        [Route("/v2/ship/{shipId}")]
        [ValidateModelState]
        [SwaggerOperation("DeleteShip")]
        public virtual IActionResult DeleteShip([FromRoute] [Required] int shipId)
        {
            try
            {
                _shipLogic.DeleteShip(shipId);
                return new OkResult();
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Find ship by ID
        /// </summary>
        /// <remarks>Returns a single ship</remarks>
        /// <param name="shipId">ID of ship to return</param>
        /// <response code="200">Operation successfull</response>
        /// <response code="400">Something went wrong</response>
        [HttpGet]
        [Route("/v2/ship/{shipId}")]
        [ValidateModelState]
        [SwaggerOperation("GetShipById")]
        [SwaggerResponse(statusCode: 200, type: typeof(Ship), description: "successful operation")]
        public virtual IActionResult GetShipById([FromRoute] [Required] int shipId)
        {
            try
            {
                var ship = _shipLogic.GetShipById(shipId);
                return new OkObjectResult(ship);
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
                throw;
            }
        }

        /// <summary>
        /// UpdateShip an existing ship
        /// </summary>
        /// <param name="body">UpdateShip an existing ship</param>
        /// <response code="200">Operation successfull</response>
        /// <response code="400">Something went wrong</response>
        [HttpPut]
        [Route("/v2/ship")]
        [ValidateModelState]
        [SwaggerOperation("UpdateShip")]
        public virtual IActionResult UpdateShip([FromBody] Ship body)
        {
            try
            {
                _shipLogic.UpdateShip(body);
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