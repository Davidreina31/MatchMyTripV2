using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.journey.commands.updateJourneyCommand;
using MatchMyTrip.Application.features.user.commands.updateUserCommand;
using MatchMyTrip.Application.features.user.dtos;
using System.Text;
using System.Text.Json;

namespace MatchMyTrip.App.services
{
    public class UserService : BaseService, IUserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
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
            var userJson =
                new StringContent(JsonSerializer.Serialize(updateUserCommand), Encoding.UTF8, "application/json");

            await _client.PutAsync(_url + "api/user", userJson);
        }
    }
}
