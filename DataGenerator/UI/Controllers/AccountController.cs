using Business.ManagerServices.Abstracts;
using Business.ManagerServices.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UI.Models;

namespace UI.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {

        IAppUserManager _appUserManager;

        public AccountController(IAppUserManager appUserManager)
        {
            _appUserManager = appUserManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            var result = await _appUserManager.SignInUser(model.UserName, model.Password, false, false);

            if (result)
            {
                TempData["success"] = "You are logged in";

                return RedirectToAction("Index", "Home");
            }else

            TempData["error"] = "Incorrect username or password";
            return View();
        } 
        
        public IActionResult Register()
        {
           

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterModel model)
        {
            var UserLoginRequest = new RegisterDTO
            {
                Email = model.Email,
                Username = model.Username,
                NameSurname = model.NameSurname,
                Password = model.Password, 
            };

            var result = await _appUserManager.CreateUserAsync(UserLoginRequest);
            if (result)
            {
                TempData["success"] = "Your account created successfully";
                return Redirect("Login");
            }

            TempData["error"] = "Invalid form";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _appUserManager.SignOutUser();
            return RedirectToAction("Index", "Home");
        }
    }
}
