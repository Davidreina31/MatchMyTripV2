using MatchMyTrip.Application.features.user.dtos;

namespace MatchMyTrip.App.Interfaces
{
    public interface ISharedService
    {
        Task<UserDTO> GetCurrentUser();
    }
}
