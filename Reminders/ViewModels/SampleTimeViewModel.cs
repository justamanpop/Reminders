using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reminders.ViewModels
{
    public class SampleTimeViewModel
    {
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime Time { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public SampleTimeViewModel()
        {

        }

        public SampleTimeViewModel(DateTime time, DateTime date, string description)
        {
            Time = time;
            Description = description;
            Date = date;
        }
    }
}
