using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.Models
{
    public class SampleTimeModel
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public SampleTimeModel()
        {

        }

        public SampleTimeModel(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }
}
