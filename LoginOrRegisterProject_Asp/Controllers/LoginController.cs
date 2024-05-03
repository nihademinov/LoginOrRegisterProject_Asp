using LoginOrRegisterProject_Asp.Models.DBEntities;
using LoginOrRegisterProject_Asp.Services;
using LoginOrRegisterProject_Asp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginOrRegisterProject_Asp.Controllers
{
    public class LoginController : Controller
    {

        private LoginService _loginService;

        public LoginController(LoginService lService)
        {
                _loginService = lService;
        }

        [HttpGet]
        public IActionResult LoginUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginUser(LoginViewModel loginModel)
        {
            var loginUser = _loginService.ConvertTypeToUser(loginModel);
            if (!ModelState.IsValid)
                return RedirectToAction("Error_404","Info");
           
            if (_loginService.CheckUser(loginUser))
                return RedirectToAction("Success","Info");

            return RedirectToAction("Error_404", "Info");

        }
    }
}
