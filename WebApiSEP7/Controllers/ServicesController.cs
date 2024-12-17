using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSEP7.Data;
using WebApiSEP7.Models;

namespace WebApiSEP7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetServices()
        {
            return await _context.Services.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> GetService(int id)
        {
            var service = await _context.Services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetService), new { id = service.ServiceId }, service);
        }

        [HttpPost("GetServicesByAnalysis")]
        public async Task<ActionResult<IEnumerable<Service>>> GetServicesByAnalysis([FromBody] AnalysisResultDto analysisResult)
        {
            var services = new List<Service>();

            if (analysisResult.DiabetesResult == "Positive")
            {
                services.AddRange(await _context.Services.Where(s => s.Category.CategoryName == "Diabetes").ToListAsync());
            }

            if (analysisResult.HeartConditionResult == "Positive")
            {
                services.AddRange(await _context.Services.Where(s => s.Category.CategoryName == "Heart").ToListAsync());
            }

            if (analysisResult.DiabetesResult == "Negative" && analysisResult.HeartConditionResult == "Negative")
            {
                services.AddRange(await _context.Services.Where(s => s.Category.CategoryName == "Basic").ToListAsync());
            }

            return Ok(services);
        }
    }

    public class AnalysisResultDto
    {
        public string DiabetesResult { get; set; }
        public string HeartConditionResult { get; set; }
    }
}