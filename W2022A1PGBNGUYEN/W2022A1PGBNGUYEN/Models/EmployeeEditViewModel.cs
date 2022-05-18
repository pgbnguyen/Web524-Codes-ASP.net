using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A1PGBNGUYEN.Models
{
    public class EmployeeEditViewModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [StringLength(30)]
        public string Title { get; set; }

        [StringLength(70)]
        public string Address { get; set; }

        [StringLength(40)]
        public string City { get; set; }

        [StringLength(40)]
        public string State { get; set; }

        [StringLength(40)]
        public string Country { get; set; }

        [StringLength(10)]
        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [StringLength(24)]
        public string Phone { get; set; }

        [StringLength(24)]
        public string Fax { get; set; }

        [StringLength(60)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [StringLength(24, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Social Insurance Numbers")]
        [StringLength(10, MinimumLength =10)]
        [RegularExpression("[0-9]+", ErrorMessage = "SIN must contain 10 digits and only numbers")]
        public string SIN { get; set; }

        [Display(Name = "Room Numbers")]
        [Range(100,175, ErrorMessage ="Selected room must range from 100 to 175")]
        public int Room { get; set; }


    }
}