using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Reminders.Models;
using Reminders.ViewModels;

namespace Reminders.Profiles
{
    public class SampleTimeModelProfile: Profile
    {
        public SampleTimeModelProfile()
        {
            CreateMap<SampleTimeModel, SampleTimeViewModel>();
        }
    }
}
