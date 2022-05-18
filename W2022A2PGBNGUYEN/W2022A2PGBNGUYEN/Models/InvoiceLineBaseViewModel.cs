﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022A2PGBNGUYEN.Models
{
    public class InvoiceLineBaseViewModel
    {
        public int InvoiceLineId { get; set; }

        public int InvoiceId { get; set; }

        public int TrackId { get; set; }

        public decimal UnitPrice { get; set; }

        public int Quantity { get; set; }

    }
}