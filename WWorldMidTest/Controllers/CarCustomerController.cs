using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WWorldMidTest.Data;
using WWorldMidTest.Repository.IRepository;
using WWorldMidTest.ViewModels;

namespace WWorldMidTest.Controllers
{
    public class CarCustomerController : Controller
    {
        private readonly CarDealerContext _context;
        public CarCustomerController(CarDealerContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Car)
                .Select(s => new SalesViewModel
                {
                    CustomerId = s.Customer.Id,
                    CustomerName = s.Customer.Name,
                    CustomerBirthDate = s.Customer.BirthDate,
                    CarMake = s.Car.Make,
                    CarModel = s.Car.Model
                }).ToList();

            return View(data);
        }
    }

}

