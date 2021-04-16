using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Reminders.Models;
using Reminders.Repository;
using Reminders.ViewModels;

namespace Reminders.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlarmRepository alarmRepository;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, IAlarmRepository alarmRepository, IMapper mapper)
        {
            _logger = logger;
            this.alarmRepository = alarmRepository;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var alarms = alarmRepository.GetAll();
            var alarmViewModels = mapper.Map<IEnumerable<SampleTimeViewModel>>(alarms).ToList(); 
            return View(alarmViewModels);
        }

        //[HttpGet]
        //public IActionResult Add()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Add()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
