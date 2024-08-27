using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Models;
using System.Data.Entity;




namespace mvc.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /ViewEmployee/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult page()
        {
           

            return View();
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        public ActionResult ViewEmployee()
        {
            ViewBag.Message = "Your contact page.";
      

            using (var db = new ApplicationDbContext())
            {
                var employees = db.Employees.ToList(); // Fetch all employees
                if (employees == null || !employees.Any())
                {
                    // Handle the case where no employees are found
                    return HttpNotFound("No employees found.");
                }
                return View(employees); // Pass the non-null list to the view
            }
        }
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                }
                TempData["SuccessMessage"] = "Employee created successfully!";
                return RedirectToAction("page"); // Redirect to page action
            }
            return View("AddEmployee", employee);
        }
        public ActionResult Edit(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
        }
        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                using (var db = new ApplicationDbContext())
                {
                    // Load the existing employee from the database
                    var existingEmployee = db.Employees.Find(employee.Id);
                    if (existingEmployee == null)
                    {
                        return HttpNotFound();
                    }

                    // Update the properties
                    existingEmployee.EmpName = employee.EmpName;
                    existingEmployee.EmpPhone = employee.EmpPhone;
                    existingEmployee.EmpDept = employee.EmpDept;
                    existingEmployee.Number = employee.Number;

                    // Save the changes
                    db.SaveChanges();
                    return RedirectToAction("ViewEmployee");
                }
            }
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
                return View(employee);
            }
        }


        // POST: Employee/DeleteConfirmed
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var employee = db.Employees.Find(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }

                db.Employees.Remove(employee);
                db.SaveChanges();
                return RedirectToAction("ViewEmployee");
            }
        }
       

	}
}