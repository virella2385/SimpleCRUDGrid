using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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
            //return View();
        }

        public JsonResult GetTestJson() 
        {
            return new JsonResult(_sqlData.GetCustomers());
        }

        public IActionResult About()
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
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       /* public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var contact = await _db.Customers.FindAsync(id);

            if (contact != null)
            {
                _db.Customers.Remove(contact);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }*/
    }

    /* [HttpGetAttribute]
     public JsonResult GetData() 
     {
         HomeViewModel viewModel = new HomeViewModel();
         viewModel.Companies = _sqlData.GetCompanies();
         return Json(new { draw = 1, recordsFiltered = viewModel.Companies.Count(), recordsTotal = viewModel.Companies.Count(), data = viewModel.Companies.ToList() });
     }*/
}

