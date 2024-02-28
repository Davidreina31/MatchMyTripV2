using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey_activity.dto;
using System.Text.Json;

namespace MatchMyTrip.App.services
{
    public class Journey_ActivityService : BaseService, IJourney_ActivityService
    {
        private readonly HttpClient _client;

        public Journey_ActivityService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Journey_ActivityQueryDTO>> GetActivitiesByJourneyId(Guid id)
        {
            var journey_activities = await JsonSerializer.DeserializeAsync<List<Journey_ActivityQueryDTO>>
                (await _client.GetStreamAsync(_url + "api/Journey_Activity/" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return journey_activities;
        }
       
    }
}
