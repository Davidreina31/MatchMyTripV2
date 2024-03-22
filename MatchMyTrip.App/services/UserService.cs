using MatchMyTrip.App.Auth0;
using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using MatchMyTrip.Application.features.journey.commands.updateJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using MatchMyTrip.Application.features.user.commands.createUserCommand;
using MatchMyTrip.Application.features.user.commands.updateUserCommand;
using MatchMyTrip.Application.features.user.dtos;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace MatchMyTrip.App.services
{
    public class UserService : BaseService, IUserService
    {
        private readonly HttpClient _client;
        private readonly IlocalStorageService _localStorageService;

        public UserService(HttpClient client, IlocalStorageService localStorageService)
        {
            _client = client;
            _localStorageService = localStorageService;
        }

        public async Task<UserDTO> CreateUser(CreateUserCommand createUserCommand)
        {
            var json =
                new StringContent(JsonSerializer.Serialize(createUserCommand), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_url + "api/User", json);

            if (response.IsSuccessStatusCode)
            {
                var userCreated = await JsonSerializer.DeserializeAsync<UserDTO>
                (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return userCreated;
            }

            return null;
        }

        public async Task<UserDTO> GetUserBySub(string sub)
        {
            var user = await JsonSerializer.DeserializeAsync<UserDTO>
                (await _client.GetStreamAsync(_url + "api/User/sub?sub=" + sub), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return user;
        }

        public async Task<UserQueryDTO> GetUserById(Guid id)
        {
            var user = await JsonSerializer.DeserializeAsync<UserQueryDTO>
                (await _client.GetStreamAsync(_url + "api/User/" + id), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return user;
        }

        public async Task<List<UserDTO>> GetUsers()
        {
            var users = await JsonSerializer.DeserializeAsync<List<UserDTO>>
                (await _client.GetStreamAsync(_url + "api/User"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return users;
        }

        public async Task UpdateUser(UpdateUserCommand updateUserCommand)
        {
            var accessToken = await _localStorageService.GetItem<AccessTokenResponse>("token");

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.access_token);

            var userJson =
                new StringContent(JsonSerializer.Serialize(updateUserCommand), Encoding.UTF8, "application/json");

            await _client.PutAsync(_url + "api/user", userJson);
        }
    }
}
