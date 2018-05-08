using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TemplateMVC.Models;

namespace TemplateMVC.DataAccessLayer
{
    public class CyborgDbContext:IdentityDbContext<AppUser, AppRole, int, AppUserLogin, AppUserRole, AppUserClaim>
    {
        public CyborgDbContext():base($"name={nameof(CyborgDbContext)}")
        {

        }
    }
}