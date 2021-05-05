using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminders.Enums;

namespace Reminders.Models
{
    public class SampleTimeModel
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public AlarmType AType { get; set; }

        public SampleTimeModel()
        {

        }

    }
}
