using CopilotApi.Models;

namespace CopilotApi.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        User Create(User user, string password);
        void Update(User user, string? password = null);
        void Delete(string id);
        User GetUser(string id);
        User GetUserById(User userId);
    }
}
