using DAPPER_CURD.AppCode;
using DAPPER_CURD.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DAPPER_CURD.Controllers
{
    public class AccountController : Controller
    {
        BL _BL = new BL();
        public readonly IHttpContextAccessor _accessor;
        public AccountController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var res = new LoginModel();
            return View(res);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel req)
        {
            var res = _BL.Dologin(req);
            if(res.Statuscode == 1)
            {
                var cliams = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, res.Name)
                };
                var identy = new ClaimsIdentity(cliams, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                };
                await HttpContext.SignInAsync(
                      CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(identy),
                      authProperties
                    );
                if(req.ReturnUrl == null || req.ReturnUrl == "/")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(req.ReturnUrl);
                }
                //_accessor.HttpContext.Session.SetString("LoginSession",JsonConvert.SerializeObject(req));
            }
            return View("Login");
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                  CookieAuthenticationDefaults.AuthenticationScheme
                  );
            return RedirectToAction("Login", "Account");
        }
    }
}
