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
    [Route("api/edit")]
    [ApiController]
    public class EditSightingController : ControllerBase
    {
        private readonly IEditSightingService _editSightingService;
        public EditSightingController(IEditSightingService editSightingService)
        {
            _editSightingService = editSightingService;
        }

        /// <summary>Edits the asynchronous.</summary>
        /// <param name="sighting">The sighting.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPut("edit-sight")]
        public async Task<IActionResult> EditAsync([FromBody] SightingViewModel sighting)
        {
            try
            {
                return Ok(await _editSightingService.EditAsync(sighting));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
