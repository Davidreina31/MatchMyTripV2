using MatchMyTrip.App.Auth0;

namespace MatchMyTrip.App.Interfaces
{
    public interface ISessionService
    {
        Task<AccessTokenResponse> GetAccessToken();
    }
}
