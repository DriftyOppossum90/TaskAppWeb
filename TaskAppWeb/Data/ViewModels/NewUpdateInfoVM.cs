using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using TaskAppWeb.Data.Base;

namespace TaskAppWeb.Models
{
    public class NewUpdateInfoVM
    {
       
        public List<int> TaskDetailsId { get; set; }

        [Display(Name ="Update Information")]
        [Required(ErrorMessage ="Information is required")]
        public string UpdateInfo { get; set; }

        public string User { get; set; }

        [Display(Name = "Date Updated")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime DateUpdated { get; set; }
    }
}
