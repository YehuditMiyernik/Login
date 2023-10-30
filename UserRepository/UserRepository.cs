using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository;

public class UserRepository
{
    private readonly string filePath = "./users.txt";
    public User GetUserByEmailAndPassword(string email, string password)
    {
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string? currentUserInFile;
            while ((currentUserInFile = reader.ReadLine()) != null)
            {
                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                if (user.UserName == email && user.Password == password)
                    return user;
            }
        }
        return null;
    }

    public User GetUserById(int id) 
    {
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string currentUserInFile;
            while ((currentUserInFile = reader.ReadLine()) != null)
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

    public User UpdateUser(int id, User updatedUser)
    {
        string textToReplace = string.Empty;
        using (StreamReader reader = System.IO.File.OpenText(filePath))
        {
            string currentUserInFile;
            while ((currentUserInFile = reader.ReadLine()) != null)
            {

                User user = JsonSerializer.Deserialize<User>(currentUserInFile);
                if (user.Id == id)
                    textToReplace = currentUserInFile;
            }
        }
        if (textToReplace != string.Empty)
        {
            string text = System.IO.File.ReadAllText(filePath);
            text = text.Replace(textToReplace, JsonSerializer.Serialize(updatedUser));
            System.IO.File.WriteAllText(filePath, text);
            return updatedUser;
        }
        return null;
    }
}

