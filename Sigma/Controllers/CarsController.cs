using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sigma.Data;
using Sigma.Models;

namespace Sigma.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarContext _context;



        public CarsController(CarContext context)
        {
            _context = context;
        }

      
       



        // GET: Cars
        public async Task<IActionResult> Index(string type, string searchString)
        {

            IQueryable<string> TypeQuery = from m in _context.TypeCar
                                           orderby m.NameOfType
                                           select m.NameOfType;

            var cars = from m in _context.Car
                       select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                cars = cars.Where(s => s.Model.Contains(searchString));
            }
            
            if (!string.IsNullOrEmpty(type))
            {
                cars = cars.Where(x => x.NameOfType == type);
            }
          

            var TypeCarVM = new TypeCarViewModel
            {
                typesCar = new SelectList(await TypeQuery.Distinct().ToListAsync()),
                Cars = await cars.ToListAsync()
            };

            return View(TypeCarVM);
        }
        //public async Task<IActionResult> Index(string SearchString)
        //{
        //    var Cars = from m in _context.Car
        //               select m;

        //    if (!String.IsNullOrEmpty(SearchString))
        //    {
        //        Cars = Cars.Where(s => s.Model.Contains(SearchString));
        //    }

        //    return View(await Cars.ToListAsync());
        //}


        // GET: Cars/Details/5
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Manufacturer,Model,EngineCapacity,TypeOfTransmition,AdditionalCharacteristics,PriceRatio,NumberOfType,NameOfType,PhotoWay")] Car car)
        {
           if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Manufacturer,Model,EngineCapacity,TypeOfTransmition,AdditionalCharacteristics,PriceRatio,NumberOfType,NameOfType,PhotoWay")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
        
    }
}
