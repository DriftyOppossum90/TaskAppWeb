using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAppWeb.Data.Base;
using TaskAppWeb.Models;

namespace TaskAppWeb.Data.Services
{
    public class TaskDetailsService : EntityBaseRepository<TaskDetails>, ITaskDetailsService
    {
        public TaskDetailsService(AppDbContext context) : base(context) { }

    }
}
