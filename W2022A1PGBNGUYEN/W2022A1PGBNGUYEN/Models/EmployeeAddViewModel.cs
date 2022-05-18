using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A1PGBNGUYEN.Models
{
    public class EmployeeAddViewModel
    {
        
            public EmployeeAddViewModel()
            {
                BirthDate = DateTime.Now.AddYears(-22);

            }

            [Required]
            [StringLength(20)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Required]
            [StringLength(20)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [StringLength(30)]
            public string Title { get; set; }

            [Display(Name = "Birth Date")]
            [DataType(DataType.Date)]
            public DateTime? BirthDate { get; set; }

            [Display(Name = "Hire Date")]
            [DataType(DataType.Date)]
            public DateTime? HireDate { get; set; }

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
        
    }
}