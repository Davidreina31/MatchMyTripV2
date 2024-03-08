using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using System.Text.Json;
using System.Text;
using MatchMyTrip.Application.features.journey.commands.updateJourneyCommand;
using System.Net.Http;
using MatchMyTrip.Application.features.user.dtos;

namespace MatchMyTrip.App.services
{
    public class JourneyService : BaseService, IJourneyService
    {
        private readonly HttpClient _client;

        public JourneyService(HttpClient client)
        {
            _client = client;
        }

        public async Task<JourneyDTO> AddJourney(CreateJourneyCommand createJourneyCommand)
        {
            var json =
                new StringContent(JsonSerializer.Serialize(createJourneyCommand), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_url + "api/Journey", json);

            if (response.IsSuccessStatusCode)
            {
                var journeyCreated = await JsonSerializer.DeserializeAsync<JourneyDTO>
                (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return journeyCreated;
            }

            return null;
        }

        public Task<List<JourneyDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<JourneyDTO> GetById(Guid id)
        {
            var journey = await JsonSerializer.DeserializeAsync<JourneyDTO>
                (await _client.GetStreamAsync(_url + "api/Journey/" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return journey;
        }

        public async Task UpdateJourney(UpdateJourneyCommand updateJourneyCommand)
        {
            var journeyJson =
                new StringContent(JsonSerializer.Serialize(updateJourneyCommand), Encoding.UTF8, "application/json");

            await _client.PutAsync(_url + "api/journey", journeyJson);
        }
    }
}
