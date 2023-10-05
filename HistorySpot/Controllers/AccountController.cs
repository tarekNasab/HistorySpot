using HistorySpot.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HistorySpot.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register (RegisterViewModel registerViewModel)
        {
            var identityUser = new IdentityUser { 
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,

            };
            var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);
            if(identityResult.Succeeded)
            {
              var roleIdentityResult =  await userManager.AddToRoleAsync(identityUser, "User");
                if (roleIdentityResult.Succeeded)
                {
                    return RedirectToAction("Register");
                }
            }
            return View("Register");
        }
        [HttpGet]
        public IActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl,
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel loginViewModel)
        {
          var signInResult =  await signInManager.PasswordSignInAsync(loginViewModel.UserName,
                loginViewModel.Password, false, false);
            if(signInResult != null && signInResult.Succeeded)
            {
                if(!string.IsNullOrEmpty(loginViewModel.ReturnUrl))
                {
                    Redirect(loginViewModel.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(loginViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
