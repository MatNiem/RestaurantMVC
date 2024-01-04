using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using RestaurantMVC.Models;

namespace RestaurantMVC.Controllers
{
    public class DishController : Controller
    {
        // GET: DishController
        public ActionResult Index()
        {
            var dishes = Repos.Repository.Dishes.ToList();
            
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
        public ActionResult Create([Bind("Id,Name,Price,Ingrediants,Preperation,IsAvaiable")] Dish dish)
        {
            if (ModelState.IsValid)
            {
                Repos.Repository.AddDish(dish);
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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DishController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
            var dish = Repos.Repository.Dishes.FirstOrDefault(d => d.Id == id);

            if (dish == null)
            {
                return NotFound();
            }

            return View(dish);
        }

        // POST: DishController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var dish = Repos.Repository.Dishes.FirstOrDefault(d => d.Id == id);
            if (dish != null)
            {
                Repos.Repository.RemoveDish(id);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
