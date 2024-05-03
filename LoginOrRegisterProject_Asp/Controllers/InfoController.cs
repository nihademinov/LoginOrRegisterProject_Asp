using Microsoft.AspNetCore.Mvc;

namespace LoginOrRegisterProject_Asp.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Error_404()
        {
            return View();
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
