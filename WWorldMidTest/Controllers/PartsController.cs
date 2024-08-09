using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WWorldMidTest.Data;
using WWorldMidTest.ViewModels;

namespace WWorldMidTest.Controllers
{
    public class PartsController : Controller
    {
        private readonly CarDealerContext _context;

        public PartsController(CarDealerContext context)
        {
            _context = context;
        }

        // GET: Parts/Create
        public IActionResult Create()
        {
            var suppliers = _context.Suppliers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();

            var viewModel = new PartViewModel
            {
                Suppliers = suppliers
            };

            return View(viewModel);
        }

        // POST: Parts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PartViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var part = new Part
                {
                    Name = viewModel.Name,
                    Price = viewModel.Price,
                    Quantity = viewModel.Quantity,
                    SupplierId = viewModel.SupplierId
                };

                _context.Parts.Add(part);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            viewModel.Suppliers = _context.Suppliers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            }).ToList();

            return View(viewModel);
        }
    }
}
