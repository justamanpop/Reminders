using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminders.Models;
using Reminders.Repository;
using Reminders.ViewModels;

namespace Reminders.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlarmRepository alarmRepository;
        private readonly IMapper mapper;

        public TestController(ILogger<HomeController> logger, IAlarmRepository alarmRepository, IMapper mapper)
        {
            _logger = logger;
            this.alarmRepository = alarmRepository;
            this.mapper = mapper;
        }

        public string Add()
        {
            alarmRepository.Add(new SampleTimeModel { Date = DateTime.Now, Hour = 12, Minute = 12, Description = "test alarm"});
            return "Added something to Db";
        }

        public string GetAll()
        {
            var alarms = alarmRepository.GetAll();
            return string.Join(',', alarms.Select(a=>a.Description));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
