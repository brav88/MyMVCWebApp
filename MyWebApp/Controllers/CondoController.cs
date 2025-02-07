using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers
{
    public class CondoController : Controller
    {
        // GET: CondoController
        public ActionResult Index()
        {
			CondominiumHelper condominiumHelper = new CondominiumHelper();

			ViewBag.Condominium = condominiumHelper.getCondominiums().Result;

            return View();
        }

        // GET: CondoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CondoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CondoController/Create
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

        // GET: CondoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CondoController/Edit/5
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

        // GET: CondoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CondoController/Delete/5
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
