using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sigma.Data;
using Sigma.Models;

namespace Sigma.Controllers
{
    public class AdminController : Controller
    {
        private readonly CarContext _context;



        public AdminController(CarContext context)
        {
            _context = context;
        }
        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }
        public async Task<IActionResult> CarList(string type, string searchString)
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
        public async Task<IActionResult> TypeCarList()
        {
            return View(await _context.TypeCar.ToListAsync());
        }
        public IActionResult AddTypeCar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTypeCar([Bind("NumberOfType,NameOfType")] TypeCar typecar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typecar);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TypeCarList));
            }
            return View(typecar);
        }
        public async Task<IActionResult> DeleteTypeCar(int? numberOfType)
        {
            if (numberOfType == null)
            {
                return NotFound();
            }   

            var typecar = await _context.TypeCar
                .FirstOrDefaultAsync(m => m.NumberOfType == numberOfType);
            if (typecar == null)
            {
                return NotFound();
            }

            return View(typecar);
        }

        [HttpPost, ActionName("DeleteTypeCar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTypeCarConfirmed(int numberOfType)
        {
            var typecar = await _context.TypeCar.FindAsync(numberOfType);
            _context.TypeCar.Remove(typecar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TypeCarList));
        }
        public IActionResult AddCar()
        {
            return View();
        }


       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCar([Bind("Id,Manufacturer,Model,EngineCapacity,TypeOfTransmition,AdditionalCharacteristics,PriceRatio,NumberOfType,NameOfType,PhotoWay")] Car car)
        {
            if (ModelState.IsValid)
            {
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(CarList));
            }
            return View(car);
        }
        public async Task<IActionResult> EditCar(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCar(int id, [Bind("Id,Manufacturer,Model,EngineCapacity,TypeOfTransmition,AdditionalCharacteristics,PriceRatio,NumberOfType,NameOfType,PhotoWay")] Car car)
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
                return RedirectToAction(nameof(CarList));
            }
            return View(car);
        }
        public async Task<IActionResult> DeleteCar(int? id)
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

        [HttpPost, ActionName("DeleteCar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteCarConfirmed(int id)
        {
            var car = await _context.Car.FindAsync(id);
            _context.Car.Remove(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(CarList));
        }
        public async Task<IActionResult> OrderList()
        {
            return View(await _context.Order.ToListAsync());
        }

    }
}