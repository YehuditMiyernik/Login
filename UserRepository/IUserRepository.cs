using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        User AddUser(User user);
        User GetUserByEmailAndPassword(string email, string password);
        User GetUserById(int id);
        User UpdateUser(int id, User updatedUser);
    }
}