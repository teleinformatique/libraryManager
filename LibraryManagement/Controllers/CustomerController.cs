using LibraryManagement.Data.Interfaces;
using LibraryManagement.Data.Model;
using LibraryManagement.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryManagement.Controllers
{
    public class CustomerController: Controller
    {

        public ICustomerRepository _customerRepository { get; }
        public IBookRepository _bookRepository { get; }

        public CustomerController(ICustomerRepository customerRepository, IBookRepository bookRepository)
        {
            _customerRepository = customerRepository;
            _bookRepository = bookRepository;
        }

        [Route("Customer")]
        public IActionResult List()
        {
            var customerVM = new List<CustomerViewModel>();
            var customers = _customerRepository.GetAll();

            if (customers.Count() == 0)
            {
                return View("Empty");
            }

            foreach (var cu in customers)
            {
                customerVM.Add(new CustomerViewModel
                {
                    Customer = cu,
                    BookCount = _bookRepository.Count(x => x.BorrowerID == cu.CustomerID)
                });
            }   

            return View(customerVM);
        }


        public IActionResult Delete(int id)
        {
            var customer = _customerRepository.GetById(id);
            _customerRepository.Delete(customer);

            return RedirectToAction("List");

        }

        [HttpGet]
        public IActionResult Create() => View();
        
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerRepository.Create(customer);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var customer = _customerRepository.GetById(id);

            return View(customer);
        }
        
        [HttpPost]
        public IActionResult Update(Customer customer)
        {
            _customerRepository.Update(customer);

            return RedirectToAction("List");
        }

    }
}
