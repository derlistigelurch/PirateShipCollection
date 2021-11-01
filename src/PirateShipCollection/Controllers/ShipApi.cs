using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PirateShipCollection.Attributes;
using PirateShipCollection.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace PirateShipCollection.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public class ShipApiController : ControllerBase
    { 
        /// <summary>
        /// Add a new ship to the store
        /// </summary>
        
        /// <param name="body">Ship object that needs to be added to the collection</param>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("/v2/ship")]
        [ValidateModelState]
        [SwaggerOperation("AddShip")]
        public virtual IActionResult AddShip([FromBody]Ship body)
        { 
            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes a pet
        /// </summary>
        
        /// <param name="shipId">Ship id to delete</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Ship not found</response>
        [HttpDelete]
        [Route("/v2/ship/{shipId}")]
        [ValidateModelState]
        [SwaggerOperation("DeletePet")]
        public virtual IActionResult DeletePet([FromRoute][Required]int? shipId)
        { 
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);


            throw new NotImplementedException();
        }

        /// <summary>
        /// Find ship by ID
        /// </summary>
        /// <remarks>Returns a single ship</remarks>
        /// <param name="shipId">ID of ship to return</param>
        /// <response code="200">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Ship not found</response>
        [HttpGet]
        [Route("/v2/ship/{shipId}")]
        [ValidateModelState]
        [SwaggerOperation("GetShipById")]
        [SwaggerResponse(statusCode: 200, type: typeof(Ship), description: "successful operation")]
        public virtual IActionResult GetShipById([FromRoute][Required]long? shipId)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Ship));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            string exampleJson = null;
            exampleJson = "{\"empty\": false}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Ship>(exampleJson)
            : default(Ship);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Update an existing ship
        /// </summary>
        
        /// <param name="body">Ship object that needs to be added to the store</param>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Ship not found</response>
        /// <response code="405">Validation exception</response>
        [HttpPut]
        [Route("/v2/ship")]
        [ValidateModelState]
        [SwaggerOperation("UpdateShip")]
        public virtual IActionResult UpdateShip([FromBody]Ship body)
        { 
            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);


            throw new NotImplementedException();
        }
    }
}
