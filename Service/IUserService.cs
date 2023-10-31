using Entities;

namespace Service
{
    public interface IUserService
    {
        User AddUser(User user);
        Task<int> CheckPassword(string password);
        Task<User> GetUserByEmailAndPassword(string email, string password);
        Task<User> GetUserById(int id);
        Task<User> UpdateUser(int id, User updatedUser);
    }
}