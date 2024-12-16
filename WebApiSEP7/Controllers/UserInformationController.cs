using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApiSEP7.Data;
using WebApiSEP7.Models;

namespace WebApiSEP7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserInformationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHttpClientFactory _httpClientFactory;

        public UserInformationController(AppDbContext context, IHttpClientFactory httpClientFactory)
        {
            _context = context;
            _httpClientFactory = httpClientFactory;
        }

        // GET: api/UserInformation/MedicalInformation
        [HttpGet("MedicalInformation")]
        public async Task<ActionResult<IEnumerable<MedicalInformation>>> GetMedicalInformation()
        {
            return await _context.MedicalInformations.ToListAsync();
        }

        // GET: api/UserInformation/PersonalInformation
        [HttpGet("PersonalInformation")]
        public async Task<ActionResult<IEnumerable<PersonalInformation>>> GetPersonalInformation()
        {
            return await _context.PersonalInformations.ToListAsync();
        }

        // POST: api/UserInformation/MedicalInformation
        [HttpPost("MedicalInformation")]
        public async Task<ActionResult<MedicalInformation>> PostMedicalInformation(MedicalInformationDto dto)
        {
            var personalInformation = await _context.PersonalInformations.FirstOrDefaultAsync(pi => pi.UserId == dto.UserId);
            if (personalInformation == null)
            {
                return NotFound("Personal information not found");
            }

            // Calculate BMI
            if (personalInformation.Height > 0)
            {
                dto.BMI = personalInformation.Weight / ((personalInformation.Height / 100) * (personalInformation.Height / 100));
            }

            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            dto.Gender = user.Gender == "Male" ? 1 : 0; // Assuming 1 for Male and 0 for Female
            dto.Age = CalculateAge(user.DateOfBirth);

            var medicalInformation = ParseDtoToMedicalInformation(dto);
            _context.MedicalInformations.Add(medicalInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMedicalInformation), new { id = medicalInformation.MedicalInformationId }, medicalInformation);
        }

        // POST: api/UserInformation/PersonalInformation
        [HttpPost("PersonalInformation")]
        public async Task<ActionResult<PersonalInformation>> PostPersonalInformation(PersonalInformation personalInformation)
        {
            _context.PersonalInformations.Add(personalInformation);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPersonalInformation), new { id = personalInformation.PersonalInformationId }, personalInformation);
        }

        // PUT: api/UserInformation/MedicalInformation/5
        [HttpPut("MedicalInformation/{id}")]
        public async Task<IActionResult> PutMedicalInformation(int id, MedicalInformationDto dto)
        {
            if (id != dto.MedicalInformationId)
            {
                return BadRequest();
            }

            var personalInformation = await _context.PersonalInformations.FirstOrDefaultAsync(pi => pi.UserId == dto.UserId);
            if (personalInformation == null)
            {
                return NotFound("Personal information not found");
            }

            // Calculate BMI
            if (personalInformation.Height > 0)
            {
                dto.BMI = personalInformation.Weight / ((personalInformation.Height / 100) * (personalInformation.Height / 100));
            }

            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            dto.Gender = user.Gender == "Male" ? 1 : 0; // Assuming 1 for Male and 0 for Female
            dto.Age = CalculateAge(user.DateOfBirth);

            var medicalInformation = ParseDtoToMedicalInformation(dto);
            _context.Entry(medicalInformation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalInformationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/UserInformation/MedicalInformation/5
        [HttpDelete("MedicalInformation/{id}")]
        public async Task<IActionResult> DeleteMedicalInformation(int id)
        {
            var medicalInformation = await _context.MedicalInformations.FindAsync(id);
            if (medicalInformation == null)
            {
                return NotFound();
            }

            _context.MedicalInformations.Remove(medicalInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/UserInformation/PersonalInformation/5
        [HttpDelete("PersonalInformation/{id}")]
        public async Task<IActionResult> DeletePersonalInformation(int id)
        {
            var personalInformation = await _context.PersonalInformations.FindAsync(id);
            if (personalInformation == null)
            {
                return NotFound();
            }

            _context.PersonalInformations.Remove(personalInformation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/UserInformation/DiabetesPrediction
        [HttpPost("DiabetesPrediction")]
        public async Task<IActionResult> DiabetesPrediction([FromBody] MedicalInformationDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            dto.Gender = user.Gender == "Male" ? 1 : 0; // Assuming 1 for Male and 0 for Female
            dto.Age = CalculateAge(user.DateOfBirth);

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync("http://localhost:5000/predict_diabetes", new { features = dto.ToDiabetesFeaturesArray() });
            if (response.IsSuccessStatusCode)
            {
                var prediction = await response.Content.ReadFromJsonAsync<PredictionResult>();
                return Ok(prediction);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }

        // POST: api/UserInformation/HeartPrediction
        [HttpPost("HeartPrediction")]
        public async Task<IActionResult> HeartPrediction([FromBody] MedicalInformationDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            dto.Gender = user.Gender == "Male" ? 1 : 0; // Assuming 1 for Male and 0 for Female
            dto.Age = CalculateAge(user.DateOfBirth);

            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync("http://localhost:5000/predict_heart", new { features = dto.ToHeartFeaturesArray(dto.Age, dto.Gender) });
            if (response.IsSuccessStatusCode)
            {
                var prediction = await response.Content.ReadFromJsonAsync<PredictionResult>();
                return Ok(prediction);
            }
            return StatusCode((int)response.StatusCode, response.ReasonPhrase);
        }
        
        [HttpPost("Predict")]
        public async Task<IActionResult> Predict([FromBody] MedicalInformationDto dto)
        {
            var user = await _context.Users.FindAsync(dto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            dto.Gender = user.Gender == "Male" ? 1 : 0; // Assuming 1 for Male and 0 for Female
            dto.Age = CalculateAge(user.DateOfBirth);

            var diabetesFeatures = dto.ToDiabetesFeaturesArray();
            var heartFeatures = dto.ToHeartFeaturesArray((int)dto.Age, dto.Gender);

            var httpClient = _httpClientFactory.CreateClient();

            var diabetesResponse = await httpClient.PostAsJsonAsync("http://localhost:5000/predict_diabetes", new { features = diabetesFeatures });
            var heartResponse = await httpClient.PostAsJsonAsync("http://localhost:5000/predict_heart", new { features = heartFeatures });

            if (diabetesResponse.IsSuccessStatusCode && heartResponse.IsSuccessStatusCode)
            {
                var diabetesPrediction = await diabetesResponse.Content.ReadFromJsonAsync<PredictionResult>();
                var heartPrediction = await heartResponse.Content.ReadFromJsonAsync<PredictionResult>();

                var combinedResult = new CombinedPredictionResult
                {
                    DiabetesPrediction = diabetesPrediction,
                    HeartPrediction = heartPrediction
                };

                return Ok(combinedResult);
            }

            return StatusCode((int)diabetesResponse.StatusCode, diabetesResponse.ReasonPhrase);
        }


        private bool MedicalInformationExists(int id)
        {
            return _context.MedicalInformations.Any(e => e.MedicalInformationId == id);
        }

        private bool PersonalInformationExists(int id)
        {
            return _context.PersonalInformations.Any(e => e.PersonalInformationId == id);
        }

            public class UserProfile
        {
            public PersonalInformation? PersonalInformation { get; set; }
            public MedicalInformation? MedicalInformation { get; set; }
        }

            public class UserIdDto
        {
            public int UserId { get; set; }
        }

    public class CombinedPredictionResult
    {
        public PredictionResult DiabetesPrediction { get; set; }
        public PredictionResult HeartPrediction { get; set; }
    }

        private MedicalInformation ParseDtoToMedicalInformation(MedicalInformationDto dto)
        {
            return new MedicalInformation
            {
                MedicalInformationId = dto.MedicalInformationId,
                UserId = dto.UserId,
                Hypertension = dto.Hypertension,
                HeartDisease = dto.HeartDisease,
                Diabetes = dto.Diabetes,
                SmokingHistory = dto.SmokingHistory,
                BMI = dto.BMI,
                HbA1cLevel = dto.HbA1cLevel,
                BloodGlucoseLevel = dto.BloodGlucoseLevel,
                RestingBP = dto.RestingBP,
                Cholesterol = dto.Cholesterol,
                FastingBS = dto.FastingBS,
                MaxHR = dto.MaxHR,
                ExerciseAngina = dto.ExerciseAngina,
                Oldpeak = dto.Oldpeak,
                ChestPainType = dto.ChestPainType,
                STSlope = dto.STSlope,
                RestingECG = dto.RestingECG,
                RestingECG_LVH = dto.RestingECG_LVH,
                RestingECG_Normal = dto.RestingECG_Normal,
                RestingECG_ST = dto.RestingECG_ST
            };
        }

        private int CalculateAge(DateTime? dateOfBirth)
        {
            if (!dateOfBirth.HasValue)
            {
                return 0;
            }

            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Value.Year;
            if (dateOfBirth.Value.Date > today.AddYears(-age)) age--;

            return age;
        }
    }

    public class MedicalInformationDto
    {
        public int MedicalInformationId { get; set; }
        public int UserId { get; set; }
        public int Hypertension { get; set; }
        public int HeartDisease { get; set; }
        public int Diabetes { get; set; }
        public int SmokingHistory { get; set; }
        public float BMI { get; set; }
        public float HbA1cLevel { get; set; }
        public int BloodGlucoseLevel { get; set; }
        public int RestingBP { get; set; }
        public int Cholesterol { get; set; }
        public int FastingBS { get; set; }
        public int MaxHR { get; set; }
        public int ExerciseAngina { get; set; }
        public float Oldpeak { get; set; }
        public ChestPainType ChestPainType { get; set; }
        public STSlope STSlope { get; set; }
        public RestingECG RestingECG { get; set; }
        public int RestingECG_LVH { get; set; }
        public int RestingECG_Normal { get; set; }
        public int RestingECG_ST { get; set; }
        public int Gender { get; set; } // Add Gender property
        public int Age { get; set; } // Add Age property

        public float[] ToDiabetesFeaturesArray()
        {
            return new float[] { Gender, Age, Hypertension, HeartDisease, SmokingHistory, BMI, HbA1cLevel, BloodGlucoseLevel };
        }

        public float[] ToHeartFeaturesArray(int age, int gender)
        {
            return new float[]
            {
                age,
                gender,
                RestingBP,
                Cholesterol,
                FastingBS,
                MaxHR,
                ExerciseAngina,
                Oldpeak,
                ChestPainType == ChestPainType.Asymptomatic ? 1 : 0,
                ChestPainType == ChestPainType.AtypicalAngina ? 1 : 0,
                ChestPainType == ChestPainType.NonAnginalPain ? 1 : 0,
                ChestPainType == ChestPainType.TypicalAngina ? 1 : 0,
                STSlope == STSlope.Downsloping ? 1 : 0,
                STSlope == STSlope.Flat ? 1 : 0,
                STSlope == STSlope.Upsloping ? 1 : 0,
                RestingECG == RestingECG.RestingECG_LVH ? 1 : 0,
                RestingECG == RestingECG.RestingECG_Normal ? 1 : 0,
                RestingECG == RestingECG.RestingECG_ST ? 1 : 0
            };
        }
    }

    public class PredictionResult
    {
        public int[][]? Prediction { get; set; }
    }
}