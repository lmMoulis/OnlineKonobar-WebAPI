using System;
using Microsoft.AspNetCore.Mvc;
using BLL.Interface;
using BLL.Models;

namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrilagodbaControllers:Controller
	{
        public readonly IPrilagodba _prilagodbaService;
        public PrilagodbaControllers(IPrilagodba prilagodbaService)
        {
            _prilagodbaService = prilagodbaService;
        }
        [HttpGet]
        public IActionResult GetAllPrilagodbe()
        {
            var prilagodbe = _prilagodbaService.GetAllPrilagodba();
            return Ok(prilagodbe);
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePrilagodba(int id)
        {
            _prilagodbaService.DeletePrilagodba(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreatePrilagodba([FromBody] Prilagodba prilagodba)
        {
            var createPrilagodba = _prilagodbaService.CreatePrilagodba(prilagodba);
            return Ok(createPrilagodba);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePrilagodba(int id, [FromBody] Prilagodba prilagodba)
        {

            var existingPrilagodba = _prilagodbaService.GetPrilagodbaId(id);
            if (existingPrilagodba == null)
            {
                return NotFound();
            }


            _prilagodbaService.UpdatePrilagodba(id, prilagodba);


            return NoContent();
        }
    }
}

