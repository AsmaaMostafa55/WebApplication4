using CompanyData.Entities;
using CompanyServices.Helper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AccountController1 : Controller
    {
        private readonly Microsoft.AspNet.Identity.UserManager<ApplicationUsercs> _userManager;
        private readonly SignInManager<ApplicationUsercs> _signInManager;
        public AccountController1(Microsoft.AspNet.Identity.UserManager<ApplicationUsercs> userManager, SignInManager<ApplicationUsercs> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModelcs input)
        {


            if (ModelState.IsValid)
            {
                var user = new ApplicationUsercs
                {
                    UserName = input.Email.Split("@")[0],
                    Email = input.Email,
                    FirstName = input.FirstName,
                    LastName = input.LastName,
                    IsActive = true
                };


                var result = await _userManager.CreateAsync(user, input.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Sign In");

                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(input);
            }



        }

        //Login
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel input)
        {
            if (!ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    if (await _userManager.CheckPasswordAsync(user, input.Password))
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, input.Password, input.RememberMe, true);
                        if (result.Succeeded)
                            return RedirectToAction("Index", "Home");

                    }
                }
                ModelState.AddModelError("", "Incorrect Email or password");
                return View(input);
            }
            return View(input);
        }
        public new async Task <IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        public IActionResult ForgetPassword ()
        {
            return View();
        }
        [HttpPost]
         public async Task< IActionResult> ForgetPassword(ForgetPasswordViewModel input)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(input.Email);
                if (user is not null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("ResetPassword", "Account", new { email=input.Email,Token=token},
                        Request.Scheme
                    );
                    var email = new Email()
                    {
                        Body = url,
                        Subject = "Reset Password",
                        To = input.Email

                    };
                    EmailSettings.SendEmail(email);
                    return RedirectToAction(nameof(CheckYourInbox));

                }
            }
            return View(input);
        }
        public IActionResult CheckYourInbox()
        {
return View();
        }
    } }


