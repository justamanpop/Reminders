using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminders.Models;
using Reminders.Repository;

namespace Reminders.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlarmRepository alarmRepository;

        public HomeController(ILogger<HomeController> logger, IAlarmRepository alarmRepository)
        {
            _logger = logger;
            this.alarmRepository = alarmRepository;
        }

        public IActionResult Index()
        {
            var alarms = alarmRepository.GetAll();
            return View(alarms);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
