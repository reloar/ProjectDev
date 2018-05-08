using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TemplateMVC.Models;

namespace TemplateMVC.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private UserManager<AppUser, int> _userManager;
        
        public AuthController()
        {
            _userManager = StartUp.UserManagerFactory.Invoke();
        }
      
        // GET: Auth
        [HttpPost]
       public ActionResult Register(RegisterInfo register, LoginInfo loginInfo)
        {
          if(!ModelState.IsValid)
            {
                return View();
            }
            var user = new AppUser
            {
                UserName = register.email,
                fullName=register.lastName + " "+ register.firstName,
                CreatedOn = DateTime.Now,
                 PhoneNumber =register.phoneNumber,
                 Email =register.email
            };
            var result = _userManager.Create(user, register.password);
            if(result.Succeeded)
            {
                 SignIn(loginInfo);
                return RedirectToAction("Login", "Auth");
            }
            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginInfo loginInfo)
        {
            
            if (this.ModelState.IsValid)
            {
                var contact = _userManager.Find(loginInfo.Username, loginInfo.Password);
                if (contact != null)
                {

                    SignIn(loginInfo);
                   
                    return Redirect(GetRedirectUrl(loginInfo.ReturnUrl));
                }
                else
                {
                    this.ModelState.AddModelError("", "Invalid Username or Password");
                }
            }
            return View(loginInfo);
        }

        private void SignIn(LoginInfo loginInfo)
        {
            ClaimsIdentity claimsIdentity = new ClaimsIdentity("ApplicationCookie");
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, loginInfo.Username));

            var ctxt = this.Request.GetOwinContext();
            ctxt.Authentication.SignIn(claimsIdentity);
        }

        public ActionResult Logout()
        {
            var ctxt = this.Request.GetOwinContext();
            ctxt.Authentication.SignOut("ApplicationCookie");

            return Redirect("Login");
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("Index", "Home");
            }
            return returnUrl;
        }

        [HttpGet]
        public ActionResult Login()
        {
            var model = new LoginInfo();
            return View(model);
        }
    }
}