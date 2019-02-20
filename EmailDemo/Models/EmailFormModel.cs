using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmailDemo.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Your name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your email"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "To"), EmailAddress]
        public string ToEmail { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Subject { get; set; }
        
        public HttpPostedFileBase Upload { get; set; }
    }
}