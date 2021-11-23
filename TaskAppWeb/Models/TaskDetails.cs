using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TaskAppWeb.Data;
using TaskAppWeb.Data.Base;
using TaskAppWeb.Data.Enums;

namespace TaskAppWeb.Models
{
    public class TaskDetails:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name ="Start Date")]
        [Required(ErrorMessage ="Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        public User User { get; set; }
        public Category Category { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

    }
}
