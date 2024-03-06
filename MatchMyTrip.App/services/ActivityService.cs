using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.commands.createActivityCommand;
using MatchMyTrip.Application.features.activity.commands.deleteActivityCommand;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.search.commands.searchByKeyWord;
using MatchMyTrip.Application.features.user.dtos;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MatchMyTrip.App.services
{
    public class ActivityService : BaseService, IActivityService
    {
        private readonly HttpClient _client;

        public ActivityService(HttpClient client)
        {
            _client = client;
        }

        public async Task<ActivityDTO> AddActivity(CreateActivityCommand activity)
        {
            var json =
                new StringContent(JsonSerializer.Serialize(activity), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_url + "api/Activity", json);

            if (response.IsSuccessStatusCode)
            {
                var activityCreated = await JsonSerializer.DeserializeAsync<ActivityDTO>
                (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return activityCreated;
            }

            return null;
        }

        public async Task DeleteActivity(DeleteActivityCommand activity)
        {
            await _client.DeleteAsync(_url + "api/Activity?Id=" + activity.Id);
        }

        public async Task<List<ActivityDTO>> GetActivities()
        {
            var activities =  await JsonSerializer.DeserializeAsync<List<ActivityDTO>>
                (await _client.GetStreamAsync(_url + "api/Activity"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return activities;
        }
    }
}
