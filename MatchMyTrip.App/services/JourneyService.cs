using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using System.Text.Json;
using System.Text;

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

        public Task<JourneyDTO> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
