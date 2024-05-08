using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KorisnikController : Controller
    {
        public readonly IKorisnik _korisnikService;
        public KorisnikController(IKorisnik korisnikService)
        {
            _korisnikService = korisnikService;
        }
        [HttpGet]
        public IActionResult GetAllKorisnici()
        {
            var korisnik = _korisnikService.GetAllKorisnik();
            return Ok(korisnik);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteKorisnik(int id)
        {
            _korisnikService?.DeleteKorisnik(id);
            return NoContent();
        }
        [HttpPost]
        public IActionResult CreateKorisnik([FromBody]Korisnik korisnik)
        {
            var createKorisnik = _korisnikService.CreateKorisnik(korisnik);
            return Ok(createKorisnik);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateKorisnik(int id, [FromBody]Korisnik korisnik)
        {
            var existingKorisnik = _korisnikService.GetKorisnikId(id);
            if(existingKorisnik ==null)
            {
                return NotFound();
            }
            _korisnikService.UpdateKorisnik(id, korisnik);
            return NoContent();
        }

    }
}
