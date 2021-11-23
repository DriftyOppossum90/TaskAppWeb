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
    public class TaskDetailsController : Controller
    {
        private readonly ITaskDetailsService _service;

        public TaskDetailsController(ITaskDetailsService service)
        {
            _service = service;

        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Description,StartDate,EndDate,Category,Priority,Status")]TaskDetails taskDetails)
        {
            if (!ModelState.IsValid) return View(taskDetails);

            await _service.AddAsync(taskDetails);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int Id)
        {
            var taskDetails = await _service.GetByIdAsync(Id);
            if (taskDetails == null) return View("Not Found");
            return View(taskDetails);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var taskDetails = await _service.GetByIdAsync(Id);
            if (taskDetails == null) return View("Not Found");
            return View(taskDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,Description,StartDate,EndDate,Category,Priority,Status")] TaskDetails taskDetails)
        {
            if (!ModelState.IsValid) return View(taskDetails);
            if(Id==taskDetails.Id)
            {
                await _service.UpdateAsync(Id, taskDetails);
                return RedirectToAction(nameof(Index));
            }
            return View(taskDetails);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var taskDetails = await _service.GetByIdAsync(Id);
            if (taskDetails == null) return View("Not Found");
            return View(taskDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int Id)
        {
            var taskDetails = await _service.GetByIdAsync(Id);
            if (taskDetails == null) return View("Not Found");

            await _service.DeleteAsync(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
