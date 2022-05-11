using Manual_Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Manual_Identity.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> UserManager;
        private readonly SignInManager<ApplicationUser> SignInManager;
        private readonly IWebHostEnvironment webHostEnvironment;
        public AccountController(UserManager<ApplicationUser> userManager,
                                   SignInManager<ApplicationUser> signInManager, IWebHostEnvironment webHostEnvironment)
        {
            this.UserManager = userManager;
            this.SignInManager = signInManager;
            this.webHostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        } 

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile img)
        {

            if (ModelState.IsValid)
            {
                string uniquefilename = string.Empty;
                if (img != null)
                {
                    string uploadsfolder = Path.Combine(webHostEnvironment.WebRootPath, "image");
                    uniquefilename = Guid.NewGuid().ToString() + "_" + img.FileName;
                    string filePath = Path.Combine(uploadsfolder, uniquefilename);
                    img.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                    Gender = model.Gender,
                    PhotoPath = uniquefilename
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ViewBag.Message = "Regirstration successful";
                    return RedirectToAction("Login","Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
    
        public IActionResult Dashboard()
        {
            return View();
        }

        //Login
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
                return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    //   userManager.LogInformation("User logged in.");
                    return RedirectToAction("Dashboard");

                }
                ModelState.AddModelError("", "Invalid Login");
            }
            return RedirectToAction("Login",model);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction("Register", "Account");
        }

        //List
        [AllowAnonymous]
        public async Task<IActionResult> UsersList()
        {
            ViewBag.Title = "Users";
            var list = await UserManager.Users.ToListAsync();
           
            return View(list);
        }
        //Edit
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user == null)
            {
               return View("NotFound");
            }
            var model = new RegisterViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName=user.UserName,
                Gender = user.Gender,
                ImgPath = user.PhotoPath

            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Edit(RegisterViewModel model, IFormFile imge)//
        {
            var user = await UserManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.Error = $"User with Id ={model.Id} not found";
                return View("NotFound");
            }
            string uniquefilename = string.Empty;
            if (imge != null)
            {
                string uploadsfolder = Path.Combine(webHostEnvironment.WebRootPath, "image");
                uniquefilename = Guid.NewGuid().ToString() + "_" + imge.FileName;
                string filePath = Path.Combine(uploadsfolder, uniquefilename);
                imge.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Gender = model.Gender;
            user.UserName = model.UserName;
            user.PhotoPath = imge == null ? user.PhotoPath : uniquefilename;
            var result = await UserManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("UsersList");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }


        public async Task<IActionResult> Detail(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await UserManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }

            return View(new RegisterViewModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName=user.UserName,
                Gender = user.Gender,
                Email = user.Email,
                ImgPath = user.PhotoPath
            });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await UserManager.FindByIdAsync(id);
            if (user == null) { return View("NotFound"); }
            else
            {
                var result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("UsersList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View("ListsUser");
            }

        }

    }
}
