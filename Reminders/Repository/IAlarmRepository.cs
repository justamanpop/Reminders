using System;
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
        Task<SampleTimeModel> Get(int id);
        Task<bool> Add(SampleTimeModel alarm);
        Task<bool> Update(SampleTimeModel alarm);
        Task<bool> Delete(int id);
    }
}
