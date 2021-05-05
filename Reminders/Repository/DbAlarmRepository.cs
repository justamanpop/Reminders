using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reminders.Contexts;
using Reminders.Models;

namespace Reminders.Repository
{
    public class DbAlarmRepository : IAlarmRepository
    {
        private readonly AlarmContext context;
        public DbAlarmRepository(AlarmContext context)
        {
            this.context = context;
        }

        public async Task<bool> Add(SampleTimeModel alarm)
        {
            context.Add(alarm);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var toBeDeleted = context.Alarms.Find(id);

            if (toBeDeleted == null)
                return false;

            context.Alarms.Remove(toBeDeleted);

            await context.SaveChangesAsync();

            return true;
        }

        public async Task<SampleTimeModel> Get(int id)
        {
            var res= await context.Alarms.FindAsync(id);
            return res;
        }

        public List<SampleTimeModel> GetAll()
        {
            return context.Alarms
                .OrderBy(a=>a.Hour)
                .ThenBy(a=>a.Minute)
                .ToList();
        }

        public async Task<bool> Update(SampleTimeModel newAlarm)
        {
            var entity = await context.Alarms.FindAsync(newAlarm.Id);
            
            if (entity == null)
            {
                return false;
            }

            context.Entry(entity).CurrentValues.SetValues(newAlarm);

            await context.SaveChangesAsync();

            return true;
        }
    }
}
