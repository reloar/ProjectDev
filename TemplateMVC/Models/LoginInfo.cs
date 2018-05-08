using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TemplateMVC.Models
{
    
    public class LoginInfo
    {
        [Required(ErrorMessage = "Required!")]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}