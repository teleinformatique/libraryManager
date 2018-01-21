using LibraryManagement.Data.Interfaces;
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

    }
}
