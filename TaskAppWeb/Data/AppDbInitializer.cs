using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAppWeb.Areas.Identity.Data;
using TaskAppWeb.Data.Enums;
using TaskAppWeb.Data.Static;
using TaskAppWeb.Models;

namespace TaskAppWeb.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Task
                if (!context.TaskDetails.Any())
                {
                    context.TaskDetails.AddRange(new List<TaskAppWeb.Models.TaskDetails>()
                    {
                        new TaskAppWeb.Models.TaskDetails()
                        {

                            Description = "Random",
                            StartDate=DateTime.Parse("12/11/2021 8:00"),
                            EndDate= DateTime.Parse("13/11/2021 8:00"),
                            //User="xyz",
                            Category=Category.Issues,
                            Priority=Priority.Normal,
                            //Status=Status.NotAssigned

                        },
                        new TaskAppWeb.Models.TaskDetails()
                        {
                            Description = "Random1",
                            StartDate=DateTime.Parse("12/11/2021 8:00"),
                            EndDate= DateTime.Parse("13/11/2021 8:00"),
                            //User="abc",
                            Category=Category.Issues,
                            Priority=Priority.Normal,
                            //Status=Status.Pending



                        }

                    });
                    context.SaveChanges();
                }

                if (!context.TaskUpdates.Any())
                {
                    context.TaskUpdates.AddRange(new List<TaskAppWeb.Models.TaskUpdate>()
                    {
                        new TaskAppWeb.Models.TaskUpdate()
                        {
                            TaskDetailsId=3,
                            UpdateInfo = "absbasd",
                            User=User.Jithu,
                            DateUpdated=DateTime.Parse("13/11/2021 8:00")

                        }
                    });
                    context.SaveChanges();
                }


            }

        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        string adminUserEmail = "admin@IT.com";
        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new ApplicationUser()
        //            {
        //                UserName = "admin",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@123");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }

        //        string appUserEmail = "user@IT.com";
        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new ApplicationUser()
        //            {
        //                UserName = "user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@123");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
