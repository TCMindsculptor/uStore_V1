using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace uStoreProject.Models
{
    public class ContactViewModel
    {
        [StringLength(100, ErrorMessage = "* Less than 100 characters")]
        [Required(ErrorMessage = "* Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "* Required")]
        [EmailAddress(ErrorMessage = "* Please enter a valid email")]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$")]
        public string Email { get; set; }

        [StringLength(25, ErrorMessage = "* Less than 25 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "* Required")]
        [UIHint("MultilineText")]
        public string Message { get; set; }
    }//class
}//namespace