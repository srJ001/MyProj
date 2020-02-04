using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sigma.Data;
using Sigma.Models;

namespace Sigma.Controllers
{
    public class OrderController : Controller
    {
        private readonly CarContext _context;
        public OrderController(CarContext context)
        {
            _context = context;
        }
        public IActionResult ApplyOrder()
        {

            return View();
        }
        public IActionResult CreateOrder()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOrder([Bind("OrderId", "CarId", "ManagerId", "UserId", "StartOfRent", "EndOfRent", "DateOfOrder", "PriceToPay")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                order.DateOfOrder = DateTime.Now;
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ApplyOrder));
            }
            return View(order);
        }
    }
}