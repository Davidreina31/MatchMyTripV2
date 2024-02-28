using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.user.dtos;
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
    }
}
