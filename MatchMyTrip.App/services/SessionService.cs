using MatchMyTrip.App.Auth0;
using MatchMyTrip.App.Interfaces;
using MatchMyTrip.Application.features.journey.commands.createJourneyCommand;
using MatchMyTrip.Application.features.journey.dto;
using System.Text.Json;
using System.Text;

namespace MatchMyTrip.App.services
{
    public class SessionService : ISessionService
    {
        private string _url = "https://dev-c4fngek5.us.auth0.com/oauth/token";

        private readonly HttpClient _client;

        public SessionService(HttpClient client)
        {
            _client = client;
        }

        public async Task<AccessTokenResponse> GetAccessToken()
        {
            LoginCredentials loginCredentials = new LoginCredentials();
            loginCredentials.client_id = "QTqMjOpJ2EeBS9E8eWS3ppfZuH792VJI";
            loginCredentials.client_secret = "rtz13Z8yX1T-xaabzsbKjQGVv3Qc6D0-kTYEWtv6bx_dXk6HdJ5ro2rs8hFW3vMb";
            loginCredentials.audience = "https://localhost:7249";
            loginCredentials.grant_type = "client_credentials";

            var json =
                new StringContent(JsonSerializer.Serialize(loginCredentials), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_url, json);

            if (response.IsSuccessStatusCode)
            {
                var accessToken = await JsonSerializer.DeserializeAsync<AccessTokenResponse>
                (await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return accessToken;
            }

            return null;
        }
    }
}