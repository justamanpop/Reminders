using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.ViewModels
{
    public class SampleTimeViewModel
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public string Description { get; set; }

        public SampleTimeViewModel()
        {

        }

        public SampleTimeViewModel(int hour, int minute, string description)
        {
            Hour = hour;
            Minute = minute;
            Description = description;
        }
    }
}
