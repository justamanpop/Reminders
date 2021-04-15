﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reminders.Models;

namespace Reminders.Repository
{
    public interface IAlarmRepository
    {
        List<SampleTimeModel> GetAll();
        SampleTimeModel Get();
        bool Add(int hour, int minute);
    }
}