using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reminders.Areas.Identity.Data;
using Reminders.Data;

[assembly: HostingStartup(typeof(Reminders.Areas.Identity.IdentityHostingStartup))]
namespace Reminders.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<RemindersAuthContext>(options =>
                    options.UseSqlite(
                        context.Configuration.GetConnectionString("RemindersAuthContextConnection")));

                services.AddDefaultIdentity<RemindersUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<RemindersAuthContext>();
            });
        }
    }
}