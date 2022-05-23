using Manual_Identity.Data;
using Manual_Identity.Models;
using Manual_Identity.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Manual_Identity.Controllers
{
    public class SalesController : Controller
    {
        private readonly AppDbContext _context;

        public SalesController(AppDbContext _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Customer()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Customer(CustomerViewModel model)
        {
            if(ModelState.IsValid)
            {
                Customer customer = new Customer()
                {
                    CustomerId = model.CustomerId,
                    CustomerName = model.CustomerName,
                };
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Student_List", "Stud_Dep");
            }        
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Item()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Item(ItemsViewModel model)
        {
            if (ModelState.IsValid)
            {
                Item item = new Item()
                {
                    ItemId = model.ItemId,
                    ItemName = model.ItemName,
                };
                _context.Items.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction("Student_List", "Stud_Dep");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Sales()
        {
            ViewBag.Customer =  _context.Customers.ToList();
            ViewBag.Item =  _context.Items.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Sales(SalesViewModel model)
        {
            if (ModelState.IsValid)
            {
                Sales sales = new Sales()
                {
                    Id = model.Id,
                    CustomerId=model.CustomerId,
                    ItemId = model.ItemId,
                    UnitPrice=model.UnitPrice,
                    SalesDate=model.SalesDate,
                    Quantity=model.Quantity,
                    
                };
                _context.Sales.Add(sales);
                await _context.SaveChangesAsync();
                return RedirectToAction("Student_List", "Stud_Dep");
            }
            return View();
        }


    }
}
