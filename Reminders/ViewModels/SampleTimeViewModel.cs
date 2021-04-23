using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.ViewModels
{
    public class SampleTimeViewModel
    {
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public DateTime Date { get; set; }
        public SampleTimeViewModel()
        {

        }

        public SampleTimeViewModel(DateTime time, string description)
        {
            Time = time;
            Description = description;
        }
    }
}
