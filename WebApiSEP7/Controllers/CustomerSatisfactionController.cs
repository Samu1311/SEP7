using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiSEP7.Models;
using WebApiSEP7.Data;

[ApiController]
[Route("api/[controller]")]
public class CustomerSatisfactionController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomerSatisfactionController(AppDbContext context)
    {
        _context = context;
    }

    // POST: api/CustomerSatisfaction/save
    [HttpPost("save")]
    public async Task<IActionResult> SaveCustomerSatisfaction([FromBody] CustomerSatisfaction customerSatisfactionModel)
    {
        if (customerSatisfactionModel == null)
        {
            return BadRequest("Customer Satisfaction data is null.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Calculate the total score (business logic)
        customerSatisfactionModel.Score = customerSatisfactionModel.Satisfaction
                                       + customerSatisfactionModel.Usability
                                       + customerSatisfactionModel.Comfort
                                       + customerSatisfactionModel.Transparency
                                       + customerSatisfactionModel.Recommendation;

        // Save it to the database
        _context.CustomerSatisfactions.Add(customerSatisfactionModel);
        await _context.SaveChangesAsync();

        return Ok(new { CustomerSatisfactionId = customerSatisfactionModel.CustomerSatisfactionId });
    }

    // GET: api/CustomerSatisfaction/get/{id}
    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetCustomerSatisfaction(int id)
    {
        var customerSatisfactionModel = await _context.CustomerSatisfactions.FirstOrDefaultAsync(cs => cs.CustomerSatisfactionId == id);

        if (customerSatisfactionModel == null)
        {
            return NotFound(new { Message = "Customer satisfaction data not found." });
        }

        return Ok(customerSatisfactionModel);
    }

    // GET: api/CustomerSatisfaction/getAll
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllCustomerSatisfactions()
    {
        var allSatisfactionData = await _context.CustomerSatisfactions.ToListAsync();
        return Ok(allSatisfactionData);
    }

    // PUT: api/CustomerSatisfaction/update/{id}
    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateCustomerSatisfaction(int id, [FromBody] CustomerSatisfaction customerSatisfactionModel)
    {
        if (customerSatisfactionModel == null || id != customerSatisfactionModel.CustomerSatisfactionId)
        {
            return BadRequest("Invalid Customer Satisfaction data.");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var existingData = await _context.CustomerSatisfactions.FindAsync(id);
        if (existingData == null)
        {
            return NotFound(new { Message = "Customer satisfaction data not found." });
        }

        // Update fields
        existingData.Satisfaction = customerSatisfactionModel.Satisfaction;
        existingData.Usability = customerSatisfactionModel.Usability;
        existingData.Comfort = customerSatisfactionModel.Comfort;
        existingData.Transparency = customerSatisfactionModel.Transparency;
        existingData.Recommendation = customerSatisfactionModel.Recommendation;
        existingData.Score = customerSatisfactionModel.Score;

        _context.CustomerSatisfactions.Update(existingData);
        await _context.SaveChangesAsync();

        return Ok(existingData);
    }

    // DELETE: api/CustomerSatisfaction/delete/{id}
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteCustomerSatisfaction(int id)
    {
        var customerSatisfactionModel = await _context.CustomerSatisfactions.FindAsync(id);
        if (customerSatisfactionModel == null)
        {
            return NotFound(new { Message = "Customer satisfaction data not found." });
        }

        _context.CustomerSatisfactions.Remove(customerSatisfactionModel);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Customer satisfaction data deleted successfully." });
    }

    // DELETE: api/CustomerSatisfaction/deleteAll
    [HttpDelete("deleteAll")]
    public async Task<IActionResult> DeleteAllCustomerSatisfaction()
    {
        try
        {
            var allSatisfactionData = await _context.CustomerSatisfactions.ToListAsync();
            _context.CustomerSatisfactions.RemoveRange(allSatisfactionData);
            await _context.SaveChangesAsync();

            return Ok(new { Message = "All customer satisfaction entries have been deleted." });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
}
