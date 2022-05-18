using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A1PGBNGUYEN.Models;

namespace W2022A1PGBNGUYEN.Controllers
{
    public class EmployeesController : Controller
    {
        private Manager m = new Manager();
        // GET: Employees
        public ActionResult Index()
        {
            var e = m.EmployeeGetAll();

            return View(e);
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            // Attempt to get the matching object
            var obj = m.EmployeeGetById(id.GetValueOrDefault()); //The GetValueOrDefault function works if the value matches the type then returns value, otherwise returns 0.
            if (obj == null)
                return HttpNotFound();
            else
                return View(obj);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            var emp = new EmployeeAddViewModel();

            return View(emp);
        }

        // POST: Employees/Create
        [HttpPost]
        public ActionResult Create(EmployeeAddViewModel newItem)
        {
            if (!ModelState.IsValid)
                return View(newItem);
            try
            {
                // Process the input
                var addedItem = m.EmployeeAdd(newItem);
                // If the item was not added, return the user to the Create page
                // otherwise redirect them to the Details page.
                if (addedItem == null)
                    return View(newItem);
                else
                    return RedirectToAction("Details", new { id = addedItem.EmployeeId });
            }
            catch
            {
                return View(newItem);
            }
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            // Attempt to fetch the matching object
            var obj = m.EmployeeGetById(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            else
            {
                // Create and configure an "edit form"
                // Notice that obj is a CustomerBaseViewModel object so
                // we must map it to a CustomerEditContactFormViewModel object
                // Notice that we can use AutoMapper anywhere,
                // and not just in the Manager class.
                var formObj = m.mapper.Map<EmployeeBaseViewModel, EmployeeEditFormViewModel>(obj);
                return View(formObj);
            }
        }

        // POST: Employees/Edit/5
        [HttpPost]
        public ActionResult Edit(int? id, EmployeeEditViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                // Validate the input
                if (!ModelState.IsValid)
                {
                    // Our "version 1" approach is to display the "edit form" again
                    return RedirectToAction("Edit", new { id = model.EmployeeId });
                }
                if (id.GetValueOrDefault() != model.EmployeeId)
                {
                    // This appears to be data tampering, so redirect the user away
                    return RedirectToAction("Index");
                }
                // Attempt to do the update
                var editedItem = m.EmployeeEditContactInfo(model);
                if (editedItem == null)
                {
                    // There was a problem updating the object
                    // Our "version 1" approach is to display the "edit form" again
                    return RedirectToAction("Edit", new { id = model.EmployeeId });
                }
                else
                {
                    // Show the details view, which will show the updated data
                    return RedirectToAction("Details", new { id = model.EmployeeId });
                }
            }
            catch
            {
                return HttpNotFound();
            }
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            var itemToDelete = m.EmployeeGetById(id.GetValueOrDefault());
            if (itemToDelete == null)
            {
                // Don't leak info about the delete attempt
                // Simply redirect
                return RedirectToAction("Index");
            }
            else
                return View(itemToDelete);
        }

        // POST: Employees/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            var result = m.EmployeeDelete(id.GetValueOrDefault());
            // "result" will be true or false
            // We probably won't do much with the result, because
            // we don't want to leak info about the delete attempt
            // In the end, we should just redirect to the list view
            return RedirectToAction("Index");
        }
    }
}
