using Manual_Identity.Data;
using Manual_Identity.Models;
using Manual_Identity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            int inv;
            Random rand = new Random();
            inv = rand.Next();
            ViewData["DateTime"] = DateTime.Now.Date;
            //DateTime dt = DateTime.Now;
            //ViewBag.dt = dt;
            ViewBag.Inv = inv;
            List<Customer> cus=new List<Customer>();
            cus = _context.Customers.ToList();
            cus.Insert(0, new Customer { CustomerId = 0, CustomerName = "Please Select Customer" });
            ViewBag.Customer = cus;

            List<Item> itm = new List<Item>();
            itm = _context.Items.ToList();
            itm.Insert(0, new Item { ItemId = 0, ItemName = "Please Select Item" });
            ViewBag.Item = itm;
            //ViewBag.Customer =  _context.Customers.ToList();
            //ViewBag.Item = _context.Items.ToList();
            return View();       
        }

        [HttpPost]
        public async Task<IActionResult> Sales(SalesMainModel model)
        {
            model.SalesDate = DateTime.Now.Date;
                Sales_Item sales = new Sales_Item()
                {
                    //SalesItem_Id = model.SalesMain_Id,
                    InvoiceNumber=model.InvoiceNumber,
                    SalesDate=model.SalesDate,
                    ItemId = model.ItemId,
                    UnitPrice=model.UnitPrice,
                    Quantity=model.Quantity,
                    
                };
                _context.Sales_Items.Add(sales);
                await _context.SaveChangesAsync();
                SalesMainModel salesmain = new SalesMainModel()
                {
                    InvoiceNumber = model.InvoiceNumber,
                    CustomerId=model.CustomerId,
                    SalesDate =model.SalesDate,
                    TotalAmount=model.TotalAmount,
                    PaidAmount=model.PaidAmount,
                    BalanceAmount=model.BalanceAmount
                };
                _context.SalesMains.Add(salesmain);
                await _context.SaveChangesAsync();
               return RedirectToAction("Student_List", "Stud_Dep");
        }

        public async Task<IActionResult> SalesList()
        {
            
            return View(await _context.SalesMains.ToListAsync());
        }
    }
}
