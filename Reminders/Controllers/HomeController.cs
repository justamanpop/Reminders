using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Reminders.Models;
using Reminders.Repository;
using Reminders.ViewModels;
using WebPush;

namespace Reminders.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAlarmRepository alarmRepository;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly ISubscriptionRepository subscriptionRepository;

        public HomeController(ILogger<HomeController> logger, IAlarmRepository alarmRepository, IMapper mapper, IConfiguration configuration, ISubscriptionRepository subscriptionRepository)
        {
            _logger = logger;
            this.alarmRepository = alarmRepository;
            this.mapper = mapper;
            this.configuration = configuration;
            this.subscriptionRepository = subscriptionRepository;
        }

        public IActionResult Index()
        {
            ViewBag.applicationServerKey = configuration["VAPID:publicKey"];
            var alarms = alarmRepository.GetAll();
            var alarmViewModels = mapper.Map<IEnumerable<SampleTimeViewModel>>(alarms).ToList(); 
            return View(alarmViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Subscription(string client, string endpoint, string p256dh, string auth)
        {
            if (client == null)
                return BadRequest("No client name was entered.");

            if (subscriptionRepository.GetClientNames().Contains(client))
                return BadRequest("Client name already in use.");

            var sub = new SubscriptionModel(endpoint, p256dh, auth, client);

            bool res= await subscriptionRepository.Add(sub);

            if (!res)
                return StatusCode(500);

            return View("Notify", subscriptionRepository.GetClientNames());
        }

        public IActionResult Notify()
        {
            return View(subscriptionRepository.GetClientNames());
        }

        [HttpPost]
        public IActionResult Notify(string message, string client)
        {
            if(client==null)
            {
                return BadRequest("No client name was chosen");
            }

            var sub = subscriptionRepository.GetSubscription(client);
            var subForPush = new PushSubscription(sub.Endpoint, sub.P256DH, sub.Auth);


            if (sub == null)
                return BadRequest("Client not found");

            var subject = configuration["VAPID:subject"];
            var publicKey = configuration["VAPID:publicKey"];
            var privateKey = configuration["VAPID:privateKey"];

            var vapidDetails = new VapidDetails(subject, publicKey, privateKey);

            var webPushClient = new WebPushClient();

            try
            {
                webPushClient.SendNotification(subForPush, message, vapidDetails);
            }
            catch (Exception e)
            {

                return BadRequest("some error in pushing occured, and it is: " + e.Message);
            }

            return View(subscriptionRepository.GetClientNames());
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
