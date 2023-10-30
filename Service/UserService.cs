using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Service;

public class UserService
{
    UserRepository userRepository = new UserRepository();

    public User GetUserByEmailAndPassword(string email, string password)
    {
        return(userRepository.GetUserByEmailAndPassword(email, password));
    }

    public User GetUserById(int id)
    {
        return userRepository.GetUserById(id);
    }

    public User AddUser(User user)
    {
        return userRepository.AddUser(user);
    }

    public int CheckPassword(string password)
    {
        var result = Zxcvbn.Core.EvaluatePassword(password);
        return result.Score;
    }

    public User UpdateUser(int id, User updatedUser)
    {
        return userRepository.UpdateUser(id, updatedUser);
    }
}
