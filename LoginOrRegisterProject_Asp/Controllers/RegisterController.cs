using AutoMapper;
using LoginOrRegisterProject_Asp.Contextes;
using LoginOrRegisterProject_Asp.Models.DBEntities;
using LoginOrRegisterProject_Asp.Services;
using LoginOrRegisterProject_Asp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoginOrRegisterProject_Asp.Controllers
{
    public class RegisterController : Controller
    {

      private RegisterService _registerService;

        public RegisterController(RegisterService rService)
        {
            _registerService = rService;    
        }

        //[HttpGet]
        //public IActionResult LoginUser()
        //{
        //    return RedirectToAction("LoginOrRegister");
        //}



        [HttpPost]
        public IActionResult LoginUser(RegisterViewModel registerModel)
        {
            var registerUser = _registerService.ConvertTypeToUser(registerModel);
            if (!ModelState.IsValid)
                return RedirectToAction("Error_404","Info");


           _registerService.AddUser(registerUser);  
            return RedirectToAction("Success","Info");

        }
    }
}
