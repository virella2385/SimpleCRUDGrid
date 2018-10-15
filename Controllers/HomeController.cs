using System;

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SimpleCRUDGridWebApp.Models;
using SimpleCRUDGridWebApp.Models.ViewModels;
using SimpleCRUDGridWebApp.Services;

namespace SimpleCRUDGridWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ISqlGridData _sqlData;
        public string sortOrder { get; set; }
        public HomeController(ISqlGridData sqlData)
        {
            _sqlData = sqlData;
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.Expenses = _sqlData.GetExpenses();
            return View(viewModel);
        }

       /* public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }*/

        public IActionResult Delete(int id)
        {
            _sqlData.DeleteExpense(id);
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

