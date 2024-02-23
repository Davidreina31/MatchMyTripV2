using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using System.Text.Json;

namespace MatchMyTrip.App.services
{
    public class ActivityService : IActivityService
    {
        private readonly HttpClient _client;
        private readonly string _url = "https://localhost:7249/";

        public ActivityService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ActivityDTO>> GetActivities()
        {
            var activities =  await JsonSerializer.DeserializeAsync<List<ActivityDTO>>
                (await _client.GetStreamAsync(_url + $"api/Activity"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return activities;
        }
    }
}
