using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trainees_Track_Courses_MVC.Models;
using Trainees_Track_Courses_MVC.View_Model;
using static Trainees_Track_Courses_MVC.View_Model.LoginVM;

namespace Trainees_Track_Courses_MVC.Controllers
{
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> userManager { get; }
        public SignInManager<ApplicationUser> signInManager { get; }
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                

                ApplicationUser userDbModel = new ApplicationUser();
                userDbModel.UserName = registerVM.UserName;
                userDbModel.FristName = registerVM.FirstName;
                userDbModel.LastName = registerVM.LastName;
                userDbModel.PasswordHash = registerVM.ConfirmPassword;
                userDbModel.PasswordHash = registerVM.Password;
                userDbModel.Email = registerVM.Email;

                IdentityResult result = await userManager.CreateAsync(userDbModel, registerVM.Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userDbModel, "Trainee"); 

                    
                    await signInManager.SignInAsync(userDbModel, false); 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Element", item.Description);  
                    }
                }
            }
            return View(registerVM);
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM userVM)
        {
            if (ModelState.IsValid)
            {
               

                ApplicationUser userModelFromDB = await userManager.FindByNameAsync(userVM.UserName);

                if (userModelFromDB != null)
                {
                    bool exist = await userManager.CheckPasswordAsync(userModelFromDB, userVM.Password);

                    if (exist == true)
                    {
                        await signInManager.SignInAsync(userModelFromDB, userVM.RemeberMe);
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ModelState.AddModelError("", "Wrong UserName Or Password!!");  
            return View(userVM);
        }


        [HttpGet]
        public IActionResult Logout()  
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
            

        }

    }
}


