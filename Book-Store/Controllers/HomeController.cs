using Book_Store.Datalayer;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class HomeController : Controller
    {
        private readonly Application context;

        public HomeController(Application context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
