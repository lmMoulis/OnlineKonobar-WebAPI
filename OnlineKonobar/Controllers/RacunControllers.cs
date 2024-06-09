using System;
using System.Net.NetworkInformation;
using Microsoft.AspNetCore.Mvc;
using BLL.Interface;
using BLL.Models;


namespace OnlineKonobar.Controllers
{
	[ApiController]
    [Route("api/[controller]")]
    public class RacunControllers :Controller
	{
		public readonly IRacun _racunService;
		public RacunControllers(IRacun racunService)
		{
			_racunService = racunService;
		}
		[HttpGet]
		public IActionResult GetAllRacuni()
		{
			var racuni = _racunService.GetAllRacun();
			return Ok(racuni);
		}
		[HttpGet("{id}")]
		public IActionResult GetAllRacunById(int id)
		{
			var racun = _racunService.GetRacunId(id);
			if(racun==null)
			{
				return NotFound();
			}
			return Ok(racun);
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteRacun(int id)
		{
			_racunService.DeleteRacun(id);
			return NoContent();
		}
		[HttpPost]
		public IActionResult CreateRacun([FromBody] Racun racun)
		{
			var createdRacun = _racunService.CreateRacun(racun);
			return Ok(createdRacun);
		}	
		[HttpPut]
		public IActionResult UpdateRacun(int id,[FromBody]Racun racun)
		{
			var existingRacun = _racunService.GetRacunId(id);
			if(existingRacun==null)
			{
				return NotFound();
			}
			_racunService.UpdateRacun(id, racun);
			return NoContent();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSkladiste(int id, [FromBody] Racun racun)
        {
            var existingRacun = _racunService.GetRacunId(id);
            if (existingRacun == null)
            {
                return NotFound();
            }
            _racunService.UpdateRacun(id, racun);
            return NoContent();
        }


    }
}

