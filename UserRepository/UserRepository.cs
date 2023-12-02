using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories;

public class UserRepository : IUserRepository
{
    private readonly Store325574630Context _Store325574630Context;
    public UserRepository(Store325574630Context store325574630Context)
    {
        _Store325574630Context = store325574630Context;
    }

    public async Task<User> GetUserByEmailAndPassword(string email, string password)
    {
        return await _Store325574630Context.Users.Where(user => user.UserName == email && user.Password == password).FirstOrDefaultAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _Store325574630Context.Users.FindAsync(id);
    }

    public async Task<User> AddUser(User user)
    {
        await _Store325574630Context.Users.AddAsync(user);
        await _Store325574630Context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(int id, User updatedUser)
    {
        _Store325574630Context.Update(updatedUser);
        _Store325574630Context.SaveChanges();
        return updatedUser;
    }
}

