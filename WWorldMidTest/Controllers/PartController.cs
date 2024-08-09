using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WWorldMidTest.Data;
using WWorldMidTest.ViewModels;

namespace WWorldMidTest.Controllers
{
    public class PartController : Controller
    {
        private readonly CarDealerContext _context;

        public PartController(CarDealerContext context)
        {
            _context = context;
        }

        // GET: Part
        public async Task<IActionResult> Index()
        {
            var carDealerContext = _context.Parts.Include(p => p.Supplier);
            return View(await carDealerContext.ToListAsync());
        }

        // GET: Part/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Parts
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
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
