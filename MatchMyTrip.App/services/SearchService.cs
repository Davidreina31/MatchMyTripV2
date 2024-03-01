using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.search.commands.dto;
using MatchMyTrip.Application.features.search.commands.searchByKeyWord;
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

        public Task<List<JourneyDTO>> GetMatchListByFilters(FilterDTO filter)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserQueryDTO>> GetMatchListByKeyWord(SearchByKeyWordCommand searchByKeyWordCommand)
        {
            searchByKeyWordCommand.KeyWord = "dave";
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
