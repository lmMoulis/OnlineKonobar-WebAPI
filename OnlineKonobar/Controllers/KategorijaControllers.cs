using Microsoft.AspNetCore.Mvc;
using BLL.Interface;
using BLL.Models;

namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KategorijaControllers : Controller
    {
        private readonly IKategorija _kategorijaService;

        public KategorijaControllers(IKategorija kategorijaService)
        {
            _kategorijaService = kategorijaService;
        }

        [HttpGet]
        public IActionResult GetAllKategorije()
        {
            var kategorije = _kategorijaService.GetAllKategorija();
            return Ok(kategorije);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteKategorija(int id)
        {
            _kategorijaService.DeleteKategorija(id);
            return NoContent();
        }

        [HttpPost]
        public IActionResult CreateKategorija([FromBody] Kategorija kategorija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdKategorija = _kategorijaService.CreateKategorija(kategorija);
            return Ok(createdKategorija);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateKategorija(int id, [FromBody] Kategorija kategorija)
        {
            var existingKategorija = _kategorijaService.GetKategorijaId(id);
            if (existingKategorija == null)
            {
                return NotFound();
            }

            _kategorijaService.UpdateKategorija(id, kategorija);

            return NoContent();
        }
    }
}
