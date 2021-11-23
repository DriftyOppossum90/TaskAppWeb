using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TaskAppWeb.Data.Base;
using TaskAppWeb.Data.Enums;

namespace TaskAppWeb.Models
{
    public class TaskUpdate:IEntityBase
    {
        [Key]
        [Display(Name ="ID")]
        public int Id { get; set; }

        [Display(Name = "Task ID")]
        public int TaskDetailsId { get; set; }
        [ForeignKey("TaskDetailsId")]

        [Display(Name = "Task Details")]
        public TaskDetails TaskDetails { get; set; }

        [Display(Name = "Update Information")]
        public string UpdateInfo { get; set; }

        public User User { get; set; }

        [Display(Name = "Date Updated")]
        public DateTime? DateUpdated { get; set; }
    }
}
