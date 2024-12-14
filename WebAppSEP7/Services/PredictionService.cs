using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class PredictionService
{
    private readonly HttpClient _httpClient;

    public PredictionService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<double[]> GetPredictionAsync(double[] features)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5000/predict", new { features });
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<PredictionResult>();
        return result.Prediction;
    }

    public class PredictionResult
    {
        public double[] Prediction { get; set; }
    }
}