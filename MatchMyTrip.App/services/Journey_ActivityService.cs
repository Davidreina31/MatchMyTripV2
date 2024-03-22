using MatchMyTrip.App.Auth0;
using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.journey_activity.commands.createJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.commands.deleteJourney_ActivityCommand;
using MatchMyTrip.Application.features.journey_activity.dtos;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace MatchMyTrip.App.services
{
    public class Journey_ActivityService : BaseService, IJourney_ActivityService
    {
        private readonly HttpClient _client;
        private readonly IlocalStorageService _localStorageService;

        public Journey_ActivityService(HttpClient client, IlocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        public async Task<Journey_ActivityDTO> AddActivityToJourney(CreateJourney_ActivityCommand createJourney_ActivityCommand)
        {
            var accessToken = await _localStorageService.GetItem<AccessTokenResponse>("token");

            if (accessToken != null)
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            var json =
                new StringContent(JsonSerializer.Serialize(createJourney_ActivityCommand), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_url + "api/Journey_Activity", json);

            if (response.IsSuccessStatusCode)
            {
                var activityForJourneyCreated = await JsonSerializer.DeserializeAsync<Journey_ActivityDTO>
                (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return activityForJourneyCreated;
            }

            return null;
        }

        public async Task DeleteJourneyActivity(DeleteJourney_ActivityCommand deleteJourney_ActivityCommand)
        {
            var accessToken = await _localStorageService.GetItem<AccessTokenResponse>("token");

            if (accessToken != null)
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            await _client.DeleteAsync(_url + "api/Journey_Activity?Id=" + deleteJourney_ActivityCommand.Id);
        }

        public async Task<List<Journey_ActivityQueryDTO>> GetActivitiesByJourneyId(Guid id)
        {
            var journey_activities = await JsonSerializer.DeserializeAsync<List<Journey_ActivityQueryDTO>>
                (await _client.GetStreamAsync(_url + "api/Journey_Activity/" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return journey_activities;
        }
       
    }
}
