using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Reminders.ViewModels;

namespace Reminders.Attributes
{
    public class DateAndTimeValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime now = DateTime.Now;

            DateTime inputDate = ((SampleTimeViewModel)value).Date;
            DateTime inputTime = ((SampleTimeViewModel)value).Time;

            if (inputDate < now)
                return false;

            //temp will hold today's date but the time is alarm's time
            DateTime temp = DateTime.Now.Date;

            temp = temp.AddHours(inputTime.Hour);
            temp = temp.AddMinutes(inputTime.Minute);
            temp = temp.AddSeconds(inputTime.Second);

            if (inputDate.Date == now.Date && temp < now)
                return false;

            return true;
        }
    }
}
