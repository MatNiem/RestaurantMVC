using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RestaurantMVC.Data;
using RestaurantMVC.Models;

namespace RestaurantMVC.Controllers
{
    public class DishController : Controller
    {

        private readonly RestaurantMVCContext _context;

        public DishController(RestaurantMVCContext context)
        {
            _context = context;
        }

        // GET: DishController
        public async Task<ActionResult> Index()
        {
            var dishes = from d in _context.Dish orderby d.Id select d;
            
            return View(dishes);
        }

        // GET: DishController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DishController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DishController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Id,Name,Price,Ingrediants,Preperation,IsAvaiable")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                dish.IsAvailable = true;
                _context.Add(dish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        // GET: DishController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DishController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("Id,Name,Price,Ingrediants,Preperation,IsAvaiable")] Dish dish)
        {
            if (id != dish.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                try
                {
                    _context.Update(dish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new Exception("marchew");
                }
                return RedirectToAction(nameof(Index));
            }
            return View(dish);
        }

        // GET: DishController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var dish = _context.Dish.FirstOrDefault(d => d.Id == id);

            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: DishController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            var dish = await _context.Dish.FindAsync(id);
            if (dish != null)
            {
                _context.Dish.Remove(dish);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
