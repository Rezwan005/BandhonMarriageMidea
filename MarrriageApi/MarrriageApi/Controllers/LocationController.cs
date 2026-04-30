using Marriage.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarrriageApi.Controllers
{
    //[Route("api/location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LocationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("divisions")]
        public async Task<IActionResult> GetDivisions()
        {
            var data = await _context.Divisions
                .OrderBy(x => x.Name)
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("districts/{divisionId}")]
        public async Task<IActionResult> GetDistricts(int divisionId)
        {
            var data = await _context.Districts
                .Where(x => x.DivisionId == divisionId)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("upazilas/{districtId}")]
        public async Task<IActionResult> GetUpazilas(int districtId)
        {
            var data = await _context.Upazilas
                .Where(x => x.DistrictId == districtId)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return Ok(data);
        }

        [HttpGet("unions/{upazilaId}")]
        public async Task<IActionResult> GetUnions(int upazilaId)
        {
            var data = await _context.Unions
                .Where(x => x.UpazilaId == upazilaId)
                .OrderBy(x => x.Name)
                .ToListAsync();

            return Ok(data);
        }
    }

}
