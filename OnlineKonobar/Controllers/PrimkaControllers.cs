using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrimkaControllers : Controller
    {
        public readonly IPrimka _primkaService;
        
        public PrimkaControllers(IPrimka primkaService)
        {
            _primkaService = primkaService;
        }
        [HttpGet]
        public IActionResult GetAllPrimka()
        {
            var primke = _primkaService.GetAllPrimka();
            return Ok(primke);
        }
        [HttpGet("date")]
        public IActionResult GetReceiptsByStockIdAndDate([FromQuery] int stockId, [FromQuery] string date)
        {
            var primke = _primkaService.GetPrimkeByStockIdAndDate(stockId, date);
            return Ok(primke);
        }
        [HttpGet("bydate")]
        public IActionResult GetReceiptsByDate([FromQuery] string date)
        {
            var primke = _primkaService.GetReceiptsByDate( date);
            return Ok(primke);
        }
        [HttpPost]
        public IActionResult CreatePrimka([FromBody] Primka primka)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdPrimka = _primkaService.CreatePrimka(primka);
            return Ok(createdPrimka);
        }
        [HttpPut("{id}")]
        public IActionResult UpdatePrimka(int id, [FromBody] Primka primka)
        {
            var existingPrimka = _primkaService.GetPrimkaId(id);
            if (existingPrimka == null)
            {
                return NotFound();
            }
            _primkaService.UpdatePrimka(id, primka);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletePrimka(int id)
        {
            _primkaService.DeletePrimka(id);
            return NoContent();
        }
    }
}
