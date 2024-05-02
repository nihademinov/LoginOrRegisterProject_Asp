using AutoMapper;
using LoginOrRegisterProject_Asp.Contextes;
using LoginOrRegisterProject_Asp.Models.DBEntities;
using LoginOrRegisterProject_Asp.Services;
using LoginOrRegisterProject_Asp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LoginOrRegisterProject_Asp.Controllers
{
    public class LoginOrRegisterController : Controller
    {

        private readonly IMapper? _mapper;
        private readonly Login_DB_Context? _context;

        public LoginOrRegisterController(IMapper mapper,Login_DB_Context context)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public IActionResult LoginOrRegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginOrRegisterUser(LoginViewModel loginModel)
        {
            bool check = false;
            User loginUser = _mapper!.Map<User>(loginModel);

            if (!ModelState.IsValid)
                return RedirectToAction("Error_404");

            var allUsers = _context!.Users.ToList();
            foreach (var user in allUsers) 
            {
                if(loginUser!=null)
                {
                    if(loginUser.Password == user.Password && loginUser.Email==user.Email) 
                    {
                        check = true;
                    }
                }
            }
            if(check)
                return RedirectToAction("Succes");


            return RedirectToAction("Error_404");

        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel registerModel)
        {
            var registerUser = _mapper!.Map<User>(registerModel);
            if (!ModelState.IsValid)
                return RedirectToAction("Error_404");
               
            
            _context!.Users.Add(registerUser);
            _context.SaveChanges();
            return RedirectToAction("Succes");

        }

        public IActionResult Succes() 
        {
            return View();
        }

        public IActionResult Error_404()
        {
            return View();
        }
    }
}
