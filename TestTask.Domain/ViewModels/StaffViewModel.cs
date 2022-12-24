using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestTask.Domain.ViewModels
{
    public class StaffViewModel
    {
        [Display(Name = "Enter name:")]
        [Required(ErrorMessage = "Empty field")]
        public string Name { get; set; }

        [Display(Name = "Enter email:")]
        [Required(ErrorMessage = "Empty field")]
        public string Email { get; set; }
    }
}
