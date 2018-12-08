using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLWeb.Areas.Admin.Models
{
    public class LogInModel
    {
        [Required]
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public LogInModel()
        {

        }
        public LogInModel(string UserName, string PassWord)
        {
            this.UserName = UserName;
            this.PassWord = PassWord;
        }
    }
}