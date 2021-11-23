using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAppWeb.Data.Base;
using TaskAppWeb.Models;

namespace TaskAppWeb.Data.Services
{
    public class TaskUpdatesService : EntityBaseRepository<TaskUpdate>, ITaskUpdatesService
    {
        public TaskUpdatesService(AppDbContext context):base(context)
        {

        }
    }
}
