
namespace StudentApp.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Allocation
    {
        public int ca_id { get; set; }
        [Required]
        public string day { get; set; }
        [Required]
        public string start_time { get; set; }
        [Required]
        public string end_time { get; set; }
        [Required]
        public string t_id { get; set; }
        [Required]
        public string class_id { get; set; }
        [Required]
        public string sub_id { get; set; }
        [Required]
        [StringLength(4, ErrorMessage = "Enter value less than 4 digits")]
        public string no_of_students { get; set; }
    }
}