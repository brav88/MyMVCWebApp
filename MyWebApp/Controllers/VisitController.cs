using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using Newtonsoft.Json;

namespace MyWebApp.Controllers
{
	public class VisitController : Controller
	{
		public UserModel GetSessionInfo()
		{
			try
			{
				if (!string.IsNullOrEmpty(HttpContext.Session.GetString("userSession")))
				{
					UserModel? user = JsonConvert.DeserializeObject<UserModel>(HttpContext.Session.GetString("userSession"));

					if (user.Type.Equals("owner"))
					{
						return user;
					}
				}

				return null;
			}
			catch
			{
				return null;
			}
		}

		// GET: VisitController
		public ActionResult Index()
		{
			UserModel? user = GetSessionInfo();

			if (user != null)
			{
				ViewBag.User = user;
				return View();
			}

			return RedirectToAction("Index", "Error");
		}

		public ActionResult Main()
		{
			UserModel? user = GetSessionInfo();

			if (user != null)
			{
				ViewBag.User = user;
				return View();
			}

			return RedirectToAction("Index", "Error");
		}

		// GET: VisitController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: VisitController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: VisitController/Create
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

		// GET: VisitController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: VisitController/Edit/5
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

		// GET: VisitController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: VisitController/Delete/5
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
