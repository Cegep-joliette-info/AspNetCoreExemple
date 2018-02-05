using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExempleAspNetCore.Controllers
{
    [Authorize]
    public class BackendController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}