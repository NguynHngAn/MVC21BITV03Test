using Microsoft.AspNetCore.Mvc;
using WWorldMidTest.Data;
using WWorldMidTest.Repository.IRepository;

namespace WWorldMidTest.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _db;
        public CustomerController(ICustomerRepository db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Customer> objCategoryList = _db.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Add(obj);
                _db.Save();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
