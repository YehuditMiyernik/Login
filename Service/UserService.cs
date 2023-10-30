using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zxcvbn;

namespace Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User GetUserByEmailAndPassword(string email, string password)
    {
        return (_userRepository.GetUserByEmailAndPassword(email, password));
    }

    public User GetUserById(int id)
    {
        return _userRepository.GetUserById(id);
    }

    public User AddUser(User user)
    {
        return _userRepository.AddUser(user);
    }

    public int CheckPassword(string password)
    {
        var result = Zxcvbn.Core.EvaluatePassword(password);
        return result.Score;
    }

    public User UpdateUser(int id, User updatedUser)
    {
        return _userRepository.UpdateUser(id, updatedUser);
    }
}
