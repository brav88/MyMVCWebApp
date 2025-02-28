﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Misc;
using MyWebApp.Models;
using Newtonsoft.Json;
using System.Text;

namespace MyWebApp.Controllers
{
	public class ProfileController : Controller
	{
		// GET: ProfileController
		public ActionResult Index()
		{
			List<Condominium> condoList = CondominiumHelper.getCondominiums().Result;

			ViewBag.CondoList = condoList;

			return View();
		}

		public ActionResult SetCount(int count)
		{		
			ViewBag.Count = count;

			return View("Index");
		}

		// GET: ProfileController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ProfileController/Create
		public ActionResult CreateOwner(string txtEmail, string txtName, string selCondo, int selCondoNumber)
		{
			try
			{				
				UserHelper userHelper = new UserHelper();
				userHelper.postUserWithEmailAndPassword(txtEmail, AppHelper.CreatePassword(), txtName, "owner", selCondo, selCondoNumber);

				return RedirectToAction("Index", "Profile");
			}
			catch
			{
				return RedirectToAction("Index", "Error");
			}			
		}

		

		// POST: ProfileController/Create
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

		// GET: ProfileController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ProfileController/Edit/5
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

		// GET: ProfileController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ProfileController/Delete/5
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
