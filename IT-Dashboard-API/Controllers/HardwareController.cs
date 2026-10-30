using IT_Dashboard_API.Data;
using IT_Dashboard_API.DTOs;
using IT_Dashboard_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IT_Dashboard_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HardwareController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HardwareController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/hardware
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HardwareDTO>>> GetHardware()
        {
            var hardware = await _context.HardwareModel 
                .Select(h => new HardwareDTO(h.AssetTag, h.DeviceType, h.Status, h.AssignedToUserId))
                .ToListAsync();

            return Ok(hardware);
        }

        // GET: api/hardware/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<HardwareDTO>> GetHardware(int id)
        {
            var hardware = await _context.HardwareModel.FindAsync(id);

            if (hardware == null)
            {
                return NotFound();
            }

            return Ok(new HardwareDTO(hardware.AssetTag, hardware.DeviceType, hardware.Status, hardware.AssignedToUserId));
        }

        // POST: api/hardware
        [HttpPost]
        public async Task<ActionResult<HardwareDTO>> CreateHardware([FromBody] HardwareDTO dto)
        {
            var hardware = new HardwareModel
            {
                AssetTag = dto.AssetTag,
                DeviceType = dto.DeviceType,
                Status = dto.Status,
                AssignedToUserId = dto.AssignedToUserId,
            };

            _context.HardwareModel.Add(hardware);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHardware), new { id = hardware.Id }, dto);
        }

        // PUT: api/hardware/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateHardware(int id, [FromBody] HardwareDTO dto)
        {
            var hardware = await _context.HardwareModel.FindAsync(id);
            if (hardware == null)
            {
                return NotFound();
            }

            hardware.AssetTag = dto.AssetTag;
            hardware.DeviceType = dto.DeviceType;
            hardware.Status = dto.Status;
            hardware.AssignedToUserId = dto.AssignedToUserId;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/hardware/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHardware(int id)
        {
            var hardware = await _context.HardwareModel.FindAsync(id);
            if (hardware == null)
            {
                return NotFound();
            }

            _context.HardwareModel.Remove(hardware);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}