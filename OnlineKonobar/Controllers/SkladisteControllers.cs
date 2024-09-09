using System;
using BLL.Interface;
using BLL.Models;
using DAL.Services;
using Microsoft.AspNetCore.Mvc;

namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkladisteControllers : Controller
    {
        public readonly ISkladiste _skladisteService;
        private readonly IInventoryService _inventoryService;
        public SkladisteControllers(ISkladiste skladisteService, IInventoryService inventoryService)
        {
            _skladisteService = skladisteService;
            _inventoryService = inventoryService;
        }
        [HttpGet]
        public IActionResult GetAllSkladiste()
        {
            var skladiste = _skladisteService.GetAllSkladiste();
            return Ok(skladiste);
        }
        [HttpGet("{id}")]
        public IActionResult GetSkladisteById(int id)
        {
            var skladiste = _skladisteService.GetSkladisteId(id);
            if(skladiste==null)
            {
                return NotFound();
            }
            return Ok(skladiste);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteSkladiste(int id)
        {
            _skladisteService.DeleteSkladiste(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateSkladiste([FromBody] Skladiste skladiste)
        {
            var createSkladiste = _skladisteService.CreateSkladiste(skladiste);
            return Ok(createSkladiste);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateSkladiste(int id, [FromBody] Skladiste skladiste)
        {
            var existingSkladiste = _skladisteService.GetSkladisteId(id);
            if (existingSkladiste == null)
            {
                return NotFound();
            }
            _skladisteService.UpdateSkladiste(id, skladiste);
            return NoContent();
        }
        [HttpGet("days-remaining/{id}")]
        public IActionResult GetDaysRemaining(int id)
        {
            try
            {
                var daysRemaining = _inventoryService.CalculateDaysRemaining(id);
                return Ok(new { DaysRemaining = daysRemaining });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("days-remaining")]
        public IActionResult GetDaysRemainingForAllArtikli()
        {
            var daysRemainingList = _inventoryService.CalculateDaysRemainingForAll();
            return Ok(daysRemainingList);
        }


    }
}

