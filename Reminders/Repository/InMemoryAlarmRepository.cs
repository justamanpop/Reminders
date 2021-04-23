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
            Add(new SampleTimeModel { Hour = 20, Minute = 20, Description="Buy orange juice", Date=  DateTime.Now.Date });
            
            Add(new SampleTimeModel { Hour = 18, Minute = 40, Description = "Walk the dog", Date = DateTime.Now.Date });
            
            Add(new SampleTimeModel { Hour = 21, Minute = 00, Description = "Watch the match", Date = DateTime.Now.Date });
            
            Add(new SampleTimeModel { Hour = 22, Minute = 15, Description = "Sleep", Date = 
                DateTime.Now.Date });
        }

        public List<SampleTimeModel> Alarms { get; set; } = new List<SampleTimeModel>();

        public bool Add(SampleTimeModel alarm)
        {
            DateTime currTime = DateTime.Now;

            alarm.Id = lastId + 1;

            Alarms.Add(alarm);
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

        public bool Update(SampleTimeModel newAlarm)
        {
            var alarm= Alarms.FirstOrDefault(a => a.Id == newAlarm.Id);

            if (alarm == null)
                return false;

            alarm = newAlarm;
            return true;
        }
    }
}
