using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reminders.Models;

namespace Reminders.Contexts
{
    public class AlarmContext: DbContext
    {
        public AlarmContext(DbContextOptions<AlarmContext> options): base(options)
        {

        }

        public DbSet<SampleTimeModel> Alarms { get; set; }
    }
}
