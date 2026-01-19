using Marriage.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarrriageApi.Controllers
{
    public class CommonController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CommonController(ApplicationDbContext context)
        {
            _context = context;
        }
      
        [HttpGet("lookupcategory/{category}")]
        public async Task<IActionResult> GetByCategory(string category)
        {
            var result = await _context.DataLookups
                .Where(x => x.Category == category && x.Status == "Active")
                .Select(x => new
                {
                    Key = x.Key,
                    Value = x.Value
                })
                .ToListAsync();

            if (!result.Any())
                return NotFound("No data found for the given category.");

            return Ok(result);
        }
    }
}
