using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Monolithic_mvc_temp.Services.Interfaces;
using Monolithic_mvc_temp.ViewModels;

namespace Monolithic_mvc_temp.Controllers
{
    [Route("[controller]/[action]")]
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmpService _empService;

        public EmployeeController(ILogger<EmployeeController> logger, IEmpService empService)
        {
            _logger = logger;
            _empService = empService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVm empVm)
        {
            if (ModelState.IsValid)
            {
                int result = await _empService.CreateEmpAsync(empVm);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}