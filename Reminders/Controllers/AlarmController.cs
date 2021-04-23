using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reminders.Models;
using Reminders.Repository;
using Reminders.ViewModels;

namespace Reminders.Controllers
{
    public class AlarmController:Controller
    {
        private readonly IAlarmRepository alarmRepository;
        private readonly IMapper mapper;

        public AlarmController(IAlarmRepository alarmRepository, IMapper mapper)
        {
            this.alarmRepository = alarmRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(SampleTimeViewModel alarm)
        {
            var alarmToAdd = mapper.Map<SampleTimeModel>(alarm);
            
            bool result=alarmRepository.Add(alarmToAdd);
            
            if(result)
                return RedirectToAction("Index","Home");

            return View();
        }
    }
}
