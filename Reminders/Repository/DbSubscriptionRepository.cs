using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reminders.Contexts;
using Reminders.Models;

namespace Reminders.Repository
{
    public class DbSubscriptionRepository : ISubscriptionRepository
    {
        private readonly MyDbContext context;

        public DbSubscriptionRepository(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<bool> Add(SubscriptionModel model)
        {
            await context.AddAsync(model);
            await context.SaveChangesAsync();
            return true;
        }

        public List<string> GetClientNames()
        {
            List<string> clients= (from model in context.SubscriptionModels
                                        select model.Client).ToList();

            return clients;

        }

        public SubscriptionModel GetSubscription(string client)
        {
            var res = from model in context.SubscriptionModels
                         where model.Client== client
                         select model;

            if (res.Count() == 0)
                return null;

            return res.ToList()[0];
        }

        public async Task<bool> Remove(SubscriptionModel model)
        {
            context.Remove(model);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
