using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OlivetVehicleTracking.Entities;

namespace OlivetVehicleTracking.Controllers
{
    public class AccountController : Controller
    {
        SignInManager<ApplicationUser> _signInManager;

        public AccountController(SignInManager<ApplicationUser> SignInManager)
        {
            _signInManager = SignInManager;
        }


        public async Task<IActionResult> Index()
        {
            var userId = 12;
            var info = await _signInManager.GetExternalLoginInfoAsync(userId.ToString());
            return View();
        }

        internal static object ConfirmEmail()
        {
            throw new NotImplementedException();
        }

        internal static object ResetPassword()
        {
            throw new NotImplementedException();
        }
    }
}
