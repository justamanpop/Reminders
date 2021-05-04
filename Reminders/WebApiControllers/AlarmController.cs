using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Reminders.Repository;

namespace Reminders.WebApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlarmController : ControllerBase
    {
        private readonly IAlarmRepository alarmRepository;
        //private readonly IMapper mapper;

        public AlarmController(IAlarmRepository alarmRepository, IMapper mapper)
        {
            this.alarmRepository = alarmRepository;
            // this.mapper = mapper;
        }

        [HttpDelete("{id}")]
        public StatusCodeResult Delete(int id)
        {
            var alarm = alarmRepository.Get(id);

            if (alarm == null)
                return NotFound();

            bool res = alarmRepository.Delete(id);

            if (res)
                return Ok();

            return StatusCode(500);

        }
    }
}
