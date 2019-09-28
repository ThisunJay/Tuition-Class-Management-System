
namespace StudentApp.Models
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;


    public partial class classroom
    {
        public int class_id { get; set; }
        [Required]
        [Range(0, 3000, ErrorMessage = "Max Can only be between 0 .. 3000")]
        public Nullable<int> max { get; set; }
        [Required]
        [Range(0, 3000, ErrorMessage = "Invalid input")]
        public Nullable<int> min { get; set; }
        [Required]
        public string location { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string ac_nonac { get; set; }
    }

}
