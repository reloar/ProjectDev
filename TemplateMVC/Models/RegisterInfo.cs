using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemplateMVC.Models
{
    public class RegisterInfo
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string phoneNumber { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]       
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string conpassword { get; set; }
           
    }
}