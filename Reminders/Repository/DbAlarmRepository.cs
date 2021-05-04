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

        public bool Delete(int id)
        {
            var toBeDeleted = Alarms.FirstOrDefault(a => a.Id == id);

            if (toBeDeleted == null)
                return false;

            Alarms.Remove(toBeDeleted);
            return true;
        }

        public SampleTimeModel Get(int id)
        {
            return Alarms.FirstOrDefault(a => a.Id == id);
        }

        public List<SampleTimeModel> GetAll()
        {
            return context.Alarms
                .OrderBy(a=>a.Hour)
                .ThenBy(a=>a.Minute)
                .ToList();
        }

        public bool Update(SampleTimeModel newAlarm)
        {
            for (int i = 0; i < Alarms.Count(); i++)
            {
                if (Alarms[i].Id == newAlarm.Id)
                {
                    Alarms[i] = newAlarm;
                    return true;
                }
            }

            return false;
        }
    }
}
