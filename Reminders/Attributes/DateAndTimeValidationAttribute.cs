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
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime now = DateTime.Now;

            DateTime inputDate = ((SampleTimeViewModel)value).Date;
            DateTime inputTime = ((SampleTimeViewModel)value).Time;

            if (inputDate < now.Date)
                return new ValidationResult("Date entered is before today's date.");

            //temp will hold today's date but the time is alarm's time
            DateTime temp = DateTime.Now.Date;

            temp = temp.AddHours(inputTime.Hour);
            temp = temp.AddMinutes(inputTime.Minute);
            temp = temp.AddSeconds(inputTime.Second);

            if (inputDate.Date == now.Date && temp < now)
                return new ValidationResult("Time entered is before current time.");

            return ValidationResult.Success;
        }
    }
}
