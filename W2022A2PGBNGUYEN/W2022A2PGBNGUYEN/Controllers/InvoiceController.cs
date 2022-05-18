using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace W2022A2PGBNGUYEN.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        private Manager m = new Manager();
        public ActionResult Index()
        {
            var myInvoices = m.InvoiceGetAll();
            return View(myInvoices);
        }
        // GET: Invoice/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var obj = m.InvoiceGetByIdWithDetail(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            else
               
                return View(obj);
        }
        
    }
}