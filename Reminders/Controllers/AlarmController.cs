﻿using System;
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
            
            alarmRepository.Add(alarmToAdd);
            
            if(ModelState.IsValid)
                return RedirectToAction("Index","Home");

            return View();
        }

        [HttpGet("{id}")]
        public IActionResult Edit(int id)
        {
            return View(id);
        }

        [HttpPost]
        public IActionResult Edit(SampleTimeViewModel alarm)
        {
            var alarmToAdd = mapper.Map<SampleTimeModel>(alarm);

            alarmRepository.Add(alarmToAdd);

            if (ModelState.IsValid)
                return RedirectToAction("Index", "Home");

            return View();
        }
    }
}
