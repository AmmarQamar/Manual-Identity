//using Manual_Identity.Models;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.DataAnnotations;

//namespace Manual_Identity.Controllers
//{
//    public class EditController : Controller
//    {

//        private readonly UserManager<ApplicationUser> _userManager;
//        private readonly SignInManager<ApplicationUser> _signInManager;
//        private readonly IWebHostEnvironment webHostEnvironment;


//        public EditController(
//                UserManager<ApplicationUser> userManager,
//                SignInManager<ApplicationUser> signInManager, IWebHostEnvironment webHostEnvironment)
//        {
//            _userManager = userManager;
//            _signInManager = signInManager;
//            webHostEnvironment = webHostEnvironment;
//        }

//        /// <summary>
//        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
//        ///     directly from your code. This API may change or be removed in future releases.
//        /// </summary>
//        public string Username { get; set; }

//        // Remaining API warnings ommited.

//        [TempData]
//        public string StatusMessage { get; set; }




//        //public class InputModel
//        //{
//        //    [Required]
//        //    [DataType(DataType.Text)]
//        //    [Display(Name = "Full name")]
//        //    public string Name { get; set; }

//        //    [Required]
//        //    [Display(Name = "Birth Date")]
//        //    [DataType(DataType.Date)]
//        //    public DateTime DOB { get; set; }

//        //    [Phone]
//        //    [Display(Name = "Phone number")]
//        //    public string PhoneNumber { get; set; }
//        //}
//        [BindProperty]
//        public InputModel Input { get; set; }
//        public class InputModel
//        {
//            [Required]
//            public string FirstName { get; set; }

//            [Required]
//            public string LastName { get; set; }

//            [Required]
//            public string Gender { get; set; }
//            public string PhotoPath { get; set; }
//        }

//        private async Task LoadAsync(ApplicationUser user, IFormFile img)
//        {
//            string uniquefilename = null;
//            if (img != null)
//            {
//                string uploadsfolder = Path.Combine(webHostEnvironment.WebRootPath, "image");
//                uniquefilename = Guid.NewGuid().ToString() + "_" + img.FileName;
//                string filePath = Path.Combine(uploadsfolder, uniquefilename);
//                img.CopyTo(new FileStream(filePath, FileMode.Create));
//            }
//            var userName = await _userManager.GetUserNameAsync(user);

//            Username = userName;

//            //Input = new InputModel
//            //{
//            //    FirstName = user.FirstName,
//            //    DOB = user.DOB,
//            //    PhoneNumber = phoneNumber
//            //};


//            Input = new InputModel
//            {
//                FirstName = user.FirstName,
//                LastName = user.LastName,
//                Gender = user.Gender,
//                PhotoPath = uniquefilename
//            };

//        }

//        public async Task<IActionResult> OnGetAsync()
//        {
//            var user = await _userManager.GetUserAsync(User);
//            if (user == null)
//            {
//                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
//            }

//            //          await LoadAsync(user);
//            return View();
//        }

//        public async Task<IActionResult> OnPostAsync(ApplicationUser model)
//        {
//            var user = await _userManager.GetUserAsync(User);
//            if (user == null)
//            {
//                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
//            }

//            if (!ModelState.IsValid)
//            {
//                //  await LoadAsync(user);
//                return View();
//            }

//            if (Input.FirstName != user.FirstName)
//            {
//                user.FirstName = Input.FirstName;
//            }

//            if (Input.LastName != user.LastName)
//            {
//                user.LastName = Input.LastName;
//            }
//            Input.Gender = model.Gender;
//            Input.PhotoPath = model.PhotoPath;

//            await _userManager.UpdateAsync(user);
//            await _signInManager.RefreshSignInAsync(user);
//            StatusMessage = "Your profile has been updated";
//            return RedirectToAction("UserList", "Account");
//        }
//    }
//}