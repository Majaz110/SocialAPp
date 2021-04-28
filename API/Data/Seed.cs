using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context)
        {
            if(await context.Users.AnyAsync())
            {
                return;
            }

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            foreach (var user in users)
            {
                var hamc = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hamc.ComputeHash(Encoding.UTF8.GetBytes("password"));
                user.PasswordSalt = hamc.Key;

                context.Users.Add(user);
                context.SaveChanges();
            }
            
        }
    }
}