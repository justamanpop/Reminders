using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reminders.Models;

namespace Reminders.Repository
{
    public class InMemoryAlarmRepository : IAlarmRepository
    {

        static int lastId = 0;

        public InMemoryAlarmRepository()
        {
            Add(20, 20, "Buy orange juice");
            Add(18, 40, "Walk the dog");
            Add(21, 00, "Watch the match");
            Add(22, 15, "Sleep");
        }

        public List<SampleTimeModel> Alarms { get; set; } = new List<SampleTimeModel>();

        public bool Add(int hour, int minute, string description)
        {
            DateTime currTime = DateTime.Now;

            if (hour < currTime.Hour || (hour == currTime.Hour && minute <= currTime.Minute))
            {
                return false;
            }

            Alarms.Add(new SampleTimeModel(hour, minute, 0, description, lastId + 1));
            lastId += 1;
            return true;
        }

        public SampleTimeModel Get(int id)
        {
            return Alarms.FirstOrDefault(a => a.Id == id);
        }

        public List<SampleTimeModel> GetAll()
        {
            return Alarms;
        }
    }
}
