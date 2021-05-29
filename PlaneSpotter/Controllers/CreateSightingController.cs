using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaneSpotter.Services;
using PlaneSpotter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter.Controllers
{
    [Route("api/create")]
    [ApiController]
    public class CreateSightingController : ControllerBase
    {
        private readonly ICreateSightingService _createSightingService;
        public CreateSightingController(ICreateSightingService createSightingService)
        {
            _createSightingService = createSightingService;
        }

        /// <summary>Creates the asynchronous.</summary>
        /// <param name="sighting">The sighting.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost("create-sight")]
        public async Task<IActionResult> CreateAsync([FromBody]SightingViewModel sighting)
        {
            try
            {
                return Ok(await _createSightingService.CreateAsync(sighting));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
