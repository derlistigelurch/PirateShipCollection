using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PirateShipCollection.Attributes;
using PirateShipCollection.Logic;
using PirateShipCollection.Models;
using PirateShipCollection.Repositories;
using Swashbuckle.AspNetCore.Annotations;

namespace PirateShipCollection.Controllers
{
    [ApiController]
    public class ShipApiController : ControllerBase
    {
        private readonly IShipLogic _shipLogic;
        private readonly BadRequestObjectResult _badRequestResult;
        private readonly OkObjectResult _okRequestResult;

        public ShipApiController(IShipLogic shipLogic)
        {
            _shipLogic = shipLogic;
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
            var id = _shipLogic.CreateShip(body);
            return id > 0
                ? new OkObjectResult(new ApiResponse { Code = 200, Message = id.ToString() })
                : _badRequestResult;
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
            return _shipLogic.DeleteShip(shipId) > 0
                ? _okRequestResult
                : _badRequestResult;
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
            var ship = _shipLogic.GetShipById(shipId);
            return ship is null
                ? _badRequestResult
                : new OkObjectResult(ship);
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
            return _shipLogic.UpdateShip(body) > 0
                ? _okRequestResult
                : _badRequestResult;
        }
    }
}