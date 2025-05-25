using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonteringService.Helpers
{
    public static class GeocodingHelper
    {
        public static async Task<(double? lat, double? lon)> GetCoordinatesAsync(string address)
        {
            var url = $"https://nominatim.openstreetmap.org/search?format=json&q={Uri.EscapeDataString(address)}";

            using var client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.ParseAdd("MonteringServiceApp");

            var response = await client.GetAsync(url);
            if (!response.IsSuccessStatusCode) return (null, null);

            var json = await response.Content.ReadAsStringAsync();
            var results = JsonSerializer.Deserialize<List<NominatimResult>>(json);

            var first = results?.FirstOrDefault();
            if (first == null) return (null, null);

            return (double.Parse(first.lat), double.Parse(first.lon));
        }

        private class NominatimResult
        {
            public string lat { get; set; }
            public string lon { get; set; }
        }
    }
}
