using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reminders.Models;

namespace Reminders.Repository
{
    public class InMemoryAlarmRepository : IAlarmRepository
    {
        public List<SampleTimeModel> Alarms { get; set; } = new List<SampleTimeModel>();
        
        public bool Add(int hour, int minute)
        {
            DateTime currTime = DateTime.Now;

            if(hour<currTime.Hour ||(hour ==currTime.Hour && minute<=currTime.Minute))
            {
                return false;
            }

            Alarms.Add(new SampleTimeModel(hour, minute, 0));
            return true;
        }

        public SampleTimeModel Get()
        {
            throw new NotImplementedException();
        }

        public List<SampleTimeModel> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
