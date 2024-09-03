using BLL.Interface;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;

namespace OnlineKonobar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OtpisControllers : Controller
    {
        public readonly IOtpis _otpisService;

        public OtpisControllers(IOtpis otpisService)
        {
            _otpisService = otpisService;
        }
        [HttpGet]
        public IActionResult GetAllOtpis()
        {
            var otpis = _otpisService.GetAllOtpis();
            return Ok(otpis);
        }
        [HttpGet("date")]
        public IActionResult GetAdjustmentByStockIdAndDate([FromQuery] int stockId, [FromQuery] string date)
        {
            var otpis = _otpisService.GetAdjustmentByStockIdAndDate(stockId, date);
            return Ok(otpis);
        }
        [HttpGet("bydate")]
        public IActionResult GetAdjustmentByDate([FromQuery] string date)
        {
            var otpis = _otpisService.GetAdjustmentByDate(date);
            return Ok(otpis);
        }
        [HttpPost]
        public IActionResult CreateOtpis([FromBody] Otpis otpis)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdOtpis = _otpisService.CreateOtpis(otpis);
            return Ok(createdOtpis);
        }
        [HttpPut("{id}")]
        public IActionResult UpdateOtpis(int id, [FromBody] Otpis otpis)
        {
            var existingOtpis = _otpisService.GetOtpisId(id);
            if (existingOtpis == null)
            {
                return NotFound();
            }
            _otpisService.UpdateOtpis(id,otpis);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteOtpis(int id)
        {
            _otpisService.DeleteOtpis(id);
            return NoContent();
        }

    }
}
