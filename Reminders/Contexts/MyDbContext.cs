using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reminders.Models;

namespace Reminders.Contexts
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {

        }

        public DbSet<SubscriptionModel> SubscriptionModels { get; set; }
    }
}
