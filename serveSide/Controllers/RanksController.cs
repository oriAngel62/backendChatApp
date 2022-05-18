using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace MVC.Controllers
{
    public class RanksController : Controller
    {
        // GET: RanksController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RanksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RanksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RanksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: RanksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RanksController/Edit/5
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

        // GET: RanksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RanksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
