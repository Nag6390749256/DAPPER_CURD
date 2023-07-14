using DAPPER_CURD.AppCode;
using DAPPER_CURD.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DAPPER_CURD.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IHttpContextAccessor _accessor;
        BL _bl = new BL();

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
            //_lr = JsonConvert.DeserializeObject<LoginModel>(_accessor.HttpContext.Session.GetString("LoginSession"));
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateV2()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel req)
        {
            var res = _bl.CreateEmp(req);
            if (res.Statuscode == 1)
            {
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["Msg"] = res.Msg;
                return View();
            }
            return View();
        }
        public IActionResult Index(int Id = 0)
        {
            if (Id == 0)
            {
                var res = _bl.GetEmp(Id);
                return View(res);
            }
            else
            {
                var res = _bl.GetEmp(Id);
                return View("Create", res.FirstOrDefault());
            }
            return View();
        }
        public IActionResult Delete(int Id = 0)
        {
            var res = _bl.DeleteEmp(Id);
            ViewData["Msg"] = res.Msg;
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
