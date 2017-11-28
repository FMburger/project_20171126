using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace demo_2017._11._26.Models
{
    public class vwLoginUser
    {
        [Display(Name = "帳號")]
        [Required]
        public string code { get; set; }
        [Display(Name = "密碼")]
        [DataType("password")]
        [Required]
        public string pwd { get; set; }
    }
}