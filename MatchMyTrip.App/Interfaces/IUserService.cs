using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.user.dto;

namespace MatchMyTrip.App.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        Task<UserDTO> GetUserById(Guid id);

    }
}
