using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A2PGBNGUYEN.Models
{
    public class InvoiceWithDetailViewModel:InvoiceBaseViewModel
    {
        public InvoiceWithDetailViewModel()
        {
            InvoiceLines = new List<InvoiceLineWithDetailViewModel>();
        }

        [Required]
        public IEnumerable<InvoiceLineWithDetailViewModel> InvoiceLines { get; set; }

        public String CustomerFirstName { get; set; }

        public String CustomerLastName { get; set; }

        public String CustomerCity { get; set; }

        public String CustomerState { get; set; }

        public String CustomerEmployeeFirstName { get; set; }

        public String CustomerEmployeeLastName { get; set; }


    }
}