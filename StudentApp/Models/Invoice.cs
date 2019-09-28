//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Invoice
    {


        [Required]
        public int invoiceId { get; set; }

        [Required]
        [StringLength(60, MinimumLength =3)]
        public string from { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public System.DateTime date { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double amount { get; set; }

        [StringLength(40, MinimumLength =3)]
        public string description { get; set; }
    }
}