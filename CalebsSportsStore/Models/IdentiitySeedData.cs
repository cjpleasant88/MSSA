using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace CalebsSportsStore.Models
{
    public class IdentiitySeedData
    {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";
        
        //This receives the UserManager<IdentityUser> as a parameter
        public static async Task EnsurePopulated(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByIdAsync(adminUser);
            if (user == null)
            {
                user = new IdentityUser("Admin");
                await userManager.CreateAsync(user, adminPassword);
            }
        }

        ////This creates a UserManager<IdentityUser>
        //public static async void EnsurePopulated(IApplicationBuilder app)
        //{
        //    UserManager<IdentityUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<IdentityUser>>();

        //    IdentityUser user = await userManager.FindByIdAsync(adminUser);
        //    if (user == null)
        //    {
        //        user = new IdentityUser("Admin");
        //        await userManager.CreateAsync(user, adminPassword);
        //    }
        //}

    }
}