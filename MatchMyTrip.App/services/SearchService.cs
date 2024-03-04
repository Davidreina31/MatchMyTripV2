using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.search.commands.dto;
using MatchMyTrip.Application.features.search.commands.searchByKeyWord;
using MatchMyTrip.Application.features.search.commands.specificSearch;
using MatchMyTrip.Application.features.user.dtos;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MatchMyTrip.App.services
{
    public class SearchService : BaseService, ISearchService
    {
        private readonly HttpClient _client;

        public SearchService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<JourneyDTO>> GetMatchListByFilters(SpecificSearchCommand specificSearchCommand)
        {
            var json =
                new StringContent(JsonSerializer.Serialize(specificSearchCommand), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_url + "api/Search/searchByFilter", json);

            if (response.IsSuccessStatusCode)
            {
                var journeys = await JsonSerializer.DeserializeAsync<List<JourneyDTO>>
                (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return journeys;
            }

            return null;
        }

        public async Task<List<UserQueryDTO>> GetMatchListByKeyWord(SearchByKeyWordCommand searchByKeyWordCommand)
        {
            var json =
                new StringContent(JsonSerializer.Serialize(searchByKeyWordCommand), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_url + "api/Search/SearchByKeyWord", json);

            if (response.IsSuccessStatusCode)
            {
                var userList = await JsonSerializer.DeserializeAsync<List<UserQueryDTO>>
                (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return userList;
            }

            return null;
        }
    }
}
