using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reminders.Models;
using Reminders.Repository;
using Reminders.ViewModels;

namespace Reminders.Controllers
{
    [Authorize]
    public class AlarmController:Controller
    {
        private readonly IAlarmRepository alarmRepository;
        private readonly IMapper mapper;

        public AlarmController(IAlarmRepository alarmRepository, IMapper mapper)
        {
            this.alarmRepository = alarmRepository;
            this.mapper = mapper;
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(SampleTimeViewModel alarm)
        {
            var alarmToAdd = mapper.Map<SampleTimeModel>(alarm);

            if (ModelState.IsValid)
            {
                await alarmRepository.Add(alarmToAdd);
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var alarmEntity = await alarmRepository.Get(id);

            var alarmVM = mapper.Map<SampleTimeViewModel>(alarmEntity);

            return View(alarmVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SampleTimeViewModel alarm)
        {
            var alarmToUpdate = mapper.Map<SampleTimeModel>(alarm);

            if (ModelState.IsValid)
            {
                bool res = await alarmRepository.Update(alarmToUpdate);
                
                if (res)
                    return RedirectToAction("Index", "Home");

                return View("Error");

            }

            return View();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var alarmEntity = await alarmRepository.Get(id);

            var alarmVM = mapper.Map<SampleTimeViewModel>(alarmEntity);

            return View(alarmVM);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            bool res = await alarmRepository.Delete(id);

            if (res)
                return RedirectToAction("Index", "Home");

            return NotFound();
        }
    }
}
