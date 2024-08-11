using System.Collections.Generic;
using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NormativiControllers : Controller
    {
        private readonly INormativi _normativService;

        public NormativiControllers(INormativi normativService)
        {
            _normativService = normativService;
        }

        [HttpGet]
        public IActionResult GetAllNormativi()
        {
            var normativi = _normativService.GetAllNormativi();
            return Ok(normativi);
        }

        [HttpGet("{id}")]
        public IActionResult GetNormativiById(int id)
        {
            var normativi = _normativService.GetNormativiId(id);
            if (normativi == null)
            {
                return NotFound();
            }
            return Ok(normativi);
        }
        [HttpGet("article/{articleId}")]
        public IActionResult GetNormativByArticleId(int articleId)
        {
            var normativi = _normativService.GetNormativByArticleId(articleId);
            if (normativi == null || normativi.Count == 0)
            {
                return NotFound();
            }
            return Ok(normativi);
        }
    }
}
