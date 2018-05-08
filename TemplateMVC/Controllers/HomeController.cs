using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace TemplateMVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
       
        // [RequireHttps]
        // GET: Home
        public HomeController()
        {
        }
        public string GetDate()
        {
            return DateTime.Now.ToLongDateString();
        }
        public ActionResult Index()
        {
            return View();
        }
    }
}