using Trainees_Track_Courses_MVC.Models;
using Trainees_Track_Courses_MVC.View_Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Trainees_Track_Courses_MVCIB.Controllers
{
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

       
            public IActionResult Index()
            {
                // Retrieve a list of roles and pass it to the view
                var roles = roleManager.Roles.ToList(); // Retrieve all roles
                var roleViewModels = roles.Select(r => new RoleVM { roleName = r.Name/*, id = r.Id*/ }).ToList();

                return View(roleViewModels);
            }

        

        [HttpGet]
        public IActionResult NewRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewRole(RoleVM roleViewModel)
        {
            if (ModelState.IsValid)
            {
                

                IdentityRole roleDbModel = new IdentityRole();
                roleDbModel.Name = roleViewModel.roleName;
                
               
                IdentityResult result = await roleManager.CreateAsync(roleDbModel);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);  
                    }
                }
            }
            return View(roleViewModel);
        }

    }
}
