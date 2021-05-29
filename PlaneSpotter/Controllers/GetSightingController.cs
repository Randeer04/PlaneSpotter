using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlaneSpotter.DTO;
using PlaneSpotter.Services;
using PlaneSpotter.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlaneSpotter.Controllers
{
    [Route("api/get")]
    [ApiController]
    public class GetSightingController : ControllerBase
    {
        private readonly IGetSightingService _getSightingService;
        public GetSightingController(IGetSightingService getSightingService)
        {
            _getSightingService = getSightingService;
        }
        /// <summary>Gets all slights asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAllSlightsAsync()
        {
            try
            {
                return Ok(await _getSightingService.GetAllSlightsAsync());
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>Gets the by identifier asynchronous.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                return Ok(await _getSightingService.GetByIdAsync(id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        /// <summary>Searches the asynchronous.</summary>
        /// <param name="searchDTO">The search dto.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost("search")]
        public async Task<IActionResult> SearchAsync([FromBody]SearchDTO searchDTO)
        {
            try
            {
                return Ok(await _getSightingService.SearchAsync(searchDTO));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
