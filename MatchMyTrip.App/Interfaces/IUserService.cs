using MatchMyTrip.Application.features.activity.dto;
using MatchMyTrip.Application.features.user.commands.updateUserCommand;
using MatchMyTrip.Application.features.user.dtos;

namespace MatchMyTrip.App.Interfaces
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetUsers();
        Task<UserQueryDTO> GetUserById(Guid id);
        Task UpdateUser(UpdateUserCommand updateUserCommand);
    }
}
