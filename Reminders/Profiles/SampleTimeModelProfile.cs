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
            CreateMap<SampleTimeModel, SampleTimeViewModel>()
                .ForMember(dest=>dest.Time, opt=> opt.MapFrom(src=> new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,src.Hour,src.Minute,0)));

            CreateMap<SampleTimeViewModel, SampleTimeModel>()
                .ForMember(dest=>dest.Hour, opt=>opt.MapFrom(src=>src.Time.Hour))
                .ForMember(dest => dest.Minute, opt => opt.MapFrom(src => src.Time.Minute));
        }
    }
}
