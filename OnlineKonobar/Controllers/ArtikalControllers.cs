using Microsoft.AspNetCore.Mvc;
using BLL.Interface;
using BLL.Models;


namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtikalControllers : Controller
    {
        public readonly IArtikal _artikalService;
        public ArtikalControllers(IArtikal artikalService)
        {
            _artikalService = artikalService;
        }
        [HttpGet]
        public IActionResult GetAllArtikli() 
        {
            var artili = _artikalService.GetAllArtikal();
            return Ok(artili);
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



    }
}
