using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository;

public class UserRepository : IUserRepository
{
    private readonly string filePath = "./users.txt";
    public async Task<User> GetUserByEmailAndPassword(string email, string password)
    {
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string? currentUserInFile;
            while ((currentUserInFile = await reader.ReadLineAsync()) != null)
            {
                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                if (user.UserName == email && user.Password == password)
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

    public User AddUser(User user)
    {
        int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
        user.Id = numberOfUsers + 1;
        string userJson = JsonSerializer.Serialize(user);
        System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
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

