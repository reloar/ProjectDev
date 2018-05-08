using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplateMVC;
using System.Web.Routing;
using TemplateMVC.Models;
using TemplateMVC.DataAccessLayer;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly:OwinStartup(typeof(StartUp))]
namespace TemplateMVC
{
	public partial class StartUp
	{

		public static Func<UserManager<AppUser, int>> UserManagerFactory { get; private set; } = Create;
		public static Func<RoleManager<AppRole, int>> RoleManagerFactory { get; private set; } = RoleCreate;

		public static void ConfigureAuth(IAppBuilder app)
		{

			//app.CreatePerOwinContext(ApplicationDbContext.Create);
			//app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

			var option = new CookieAuthenticationOptions()
			{
				AuthenticationType="ApplicationCookie",
				CookieName = "Redirecting",
				LoginPath = new PathString("/Auth/Login"),
				
			};
			app.UseCookieAuthentication(option);

			//app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

			//// Uncomment the following lines to enable logging in with third party login providers
			////app.UseMicrosoftAccountAuthentication(
			////    clientId: "",
			////    clientSecret: "");

			////app.UseTwitterAuthentication(
			////   consumerKey: "",
			////   consumerSecret: "");

			////app.UseFacebookAuthentication(
			////   appId: "",
			////   appSecret: "");


			//app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
			//{
			//     clientId: "1061819613782-9gp32aa3tht0f5rqdgqk5dinqr53bt7m.apps.googleusercontent.com",
			//clientSecret: "B7nw6w4edHgYzp3UIRuuhcHd"
			//});

		   
			}
		public static UserManager<AppUser, int> Create()

		{

			var dbContext = new CyborgDbContext();
			var store = new UserStore<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>(dbContext);
			var usermanager = new UserManager<AppUser, int>(store);
			// allow alphanumeric characters in username
			usermanager.UserValidator = new UserValidator<AppUser, int>(usermanager)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = false,
			};

			usermanager.PasswordValidator = new PasswordValidator()
			{
				RequiredLength = 4,
				RequireDigit = false,
				RequireUppercase = false
			};

			return usermanager;
		}

		public static RoleManager<AppRole, int> RoleCreate()
		{
			var dbContext = new CyborgDbContext();
			var store = new RoleStore<AppRole, int, AppUserRole>(dbContext);
			var rolemanager = new RoleManager<AppRole, int>(store);
			return rolemanager;
		}
	}
}