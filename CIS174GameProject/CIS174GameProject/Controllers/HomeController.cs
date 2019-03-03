using CIS174GameProject.ErrorReport;
using System.Web.Mvc;

namespace CIS174GameProject.Controllers
{
    [ExceptionHandler]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
        
    }
}