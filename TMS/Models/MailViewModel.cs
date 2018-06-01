using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.Models
{
    public class MailViewModel
    {
        public MailViewModel() { }

        public MailViewModel(string email, string comment)
        {
            Email = email;
            Comment = comment;
        }

        [Required][EmailAddress]
        public string Email { get; set; }

        [Required][MinLength(20)][MaxLength(300)]
        public string Comment { get; set; }
    }
}
