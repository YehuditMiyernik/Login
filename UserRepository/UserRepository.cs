using Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository;

public class UserRepository : IUserRepository
{
    private readonly Store325574630Context _Store325574630Context;
    public UserRepository()
    {
        _Store325574630Context = new Store325574630Context();
    }

    private string filePath = "/";

    public async Task<User> GetUserByEmailAndPassword(string email, string password)
    {
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string? currentUserInFile;
            while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            {
                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                //if (user.UserName == email && user.Password == password)
                    return user;
            }
        }
        return null;
    }

    public async Task<User> GetUserById(int id)
    {
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string currentUserInFile;
            while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            {
                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                if (user.Id == id)
                    return user;
            }
            return null;
        }
    }

    public async Task<User> AddUser(User user)
    {
        await _Store325574630Context.AddAsync(user);
        await _Store325574630Context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(int id, User updatedUser)
    {
        string textToReplace = string.Empty;
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string currentUserInFile;
            while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            {

                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                if (user.Id == id)
                    textToReplace = currentUserInFile;
            }
        }
        if (textToReplace != string.Empty)
        {
            string text = await System.IO.File.ReadAllTextAsync(filePath);
            text = text.Replace(textToReplace, JsonSerializer.Serialize(updatedUser));
            await System.IO.File.WriteAllTextAsync(filePath, text);
            return updatedUser;
        }
        return null;
    }
}

