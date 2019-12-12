using Microsoft.AspNetCore.Identity;
using NotesAppFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesAppFinal
{
    public class ApplicationDBRoleInitializer
    {
        public static void SeedUsers(UserManager<NotesUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@test.com").Result == null)
            {
                NotesUser user = new NotesUser
                {
                    FirstName = "Admin",
                    LastName = "",
                    UserName = "admin@test.com",
                    Email = "admin@test.com"
                };
                IdentityResult result = userManager.CreateAsync(user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
    }
}
