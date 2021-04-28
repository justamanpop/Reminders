using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminders.Models;

namespace Reminders.Repository
{
    public interface ISubscriptionRepository
    {
        public List<string> GetClientNames();
        public Task<bool> Add(SubscriptionModel model);
        public Task<bool> Remove(SubscriptionModel model);
        public SubscriptionModel GetSubscription(string client);
    }
}
