using Microsoft.AspNetCore.Mvc;
using BLL.Interface;
using BLL.Models;
using DAL.Services;


namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtikalControllers : Controller
    {
        public readonly IArtikal _artikalService;
        private readonly IInventoryService _inventoryService;
        public ArtikalControllers(IArtikal artikalService, IInventoryService inventoryService)
        {
            _artikalService = artikalService;
            _inventoryService = inventoryService;
        }
        [HttpGet]
        public IActionResult GetAllArtikli() 
        {
            var artili = _artikalService.GetAllArtikal();
            return Ok(artili);
        }
        [HttpGet("{id}")]
        public IActionResult GetArtikalById(int id)
        {
            var artikal = _artikalService.GetArtikaldId(id);
            if (artikal == null)
            {
                return NotFound();
            }
            return Ok(artikal);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteArtikal(int id)
        {
            _artikalService.DeleteArtikal(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateArtikal([FromBody] Artikal artikal)
        {
            var createdArtikal = _artikalService.CreateArtikal(artikal);
            return Ok(createdArtikal);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateArtikal(int id, [FromBody] Artikal artikal)
        {
            var existingArtikal = _artikalService.GetArtikaldId(id);
            if (existingArtikal == null)
            {
                return NotFound();
            }
            _artikalService.UpdateArtikal(id, artikal);

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
