using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAppWeb.Data;
using TaskAppWeb.Data.Services;
using TaskAppWeb.Models;

namespace TaskAppWeb.Controllers
{
    [Authorize]
    public class TaskUpdatesController : Controller
    {
        private readonly ITaskUpdatesService _service;
        public TaskUpdatesController(ITaskUpdatesService service)
        {
            _service=service;

        }
        public async Task<IActionResult> Index()
        {
            var updatedata = await _service.GetAllAsync();
            return View(updatedata);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var taskUpdate = await _service.GetByIdAsync(Id);
            if (taskUpdate == null) return View("NotFound");
            return View(taskUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,TaskDetailsId,UpdateInfo,User,DateUpdated")] TaskUpdate taskUpdates)
        {
            if (!ModelState.IsValid) return View(taskUpdates);
            await _service.UpdateAsync(Id, taskUpdates);
            return RedirectToAction(nameof(Index));
        }

    }
}
