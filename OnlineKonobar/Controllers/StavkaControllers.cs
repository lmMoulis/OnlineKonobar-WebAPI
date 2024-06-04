using System;
using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StavkaControllers :Controller
	{
        public readonly IStavka _stavkaService;
        public StavkaControllers(IStavka stavkaService)
        {
            _stavkaService = stavkaService;
        }
        [HttpGet]
        public IActionResult GetAllStavka()
        {
            var stavka = _stavkaService.GetAllStavka();
            return Ok(stavka);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStavka(string id)
        {
            _stavkaService.DeleteStavka(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateStavka([FromBody] Stavka stavka)
        {
            var createdStavka = _stavkaService.CreateStavka(stavka);
            return Ok(createdStavka);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStavka(string id, [FromBody] Stavka stavka)
        {

            var existingStavka = _stavkaService.GetStavkaId(id);
            if (existingStavka == null)
            {
                return NotFound();
            }


            _stavkaService.UpdateStavka(id, stavka);


            return NoContent();
        }

    }
}

