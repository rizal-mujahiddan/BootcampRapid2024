using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RapidBootcamp.WebApplication.DAL;
using RapidBootcamp.WebApplication.Models;

namespace RapidBootcamp.WebApplication.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomer _customerDal;
        public CustomersController(ICustomer customerDal)
        {
            _customerDal = customerDal;
        }

        // GET: CustomersController
        public ActionResult Index(string customernameorcity="")
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            IEnumerable<Customer> customers;
            if (customernameorcity != "")
            {
                customers = _customerDal.GetCustomersByNameOrCity(customernameorcity);
            }
            else
            {
                customers = _customerDal.GetAll();
            }

            return View(customers);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var customer = _customerDal.GetById(id);
            return View(customer);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var result = _customerDal.Add(customer);

                TempData["Message"] = $"Customer {customer.CustomerName} added successfully";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Customer not added";
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _customerDal.GetById(id);

            return View(category);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                var result = _customerDal.Update(customer);
                TempData["Message"] = $"Customer {customer.CustomerName} updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Customer not updated";
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _customerDal.GetById(id);
            return View(customer);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeletePost(int CustomerId)
        {
            try
            {
                _customerDal.Delete(CustomerId);
                TempData["Message"] = $"Customer with id:{CustomerId} deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.ErrorMessage = "Customer not deleted";
                return View();
            }
        }
    }
}
