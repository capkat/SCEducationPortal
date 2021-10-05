using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCEducationPortal.Business.Commons.Models.EducationContentFileModels;
using SCEducationPortal.Business.Commons.Models.EducationContentModels;
using SCEducationPortal.Business.Commons.Models.EducationModels;
using SCEducationPortal.Business.Commons.Models.UserModels;
using SCEducationPortal.Business.IEngines;
using SCEducationPortal.Data.Authentication;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Controllers
{
    [Authorize()]
    public class ProfileController : Controller
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        private readonly ILogger<EducationController> _logger;
        private readonly IEducationEngine _educationEngine;
        private readonly ICategoryEngine _categoryEngine;
        private readonly IEducationContentEngine _educationContentEngine;
        private readonly IEducationContentFileEngine _educationContentFileEngine;


        public ProfileController(ILogger<EducationController> logger, IEducationEngine educationEngine, RoleManager<AppRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ICategoryEngine categoryEngine, IEducationContentEngine educationContentEngine, IEducationContentFileEngine educationContentFileEngine)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _educationEngine = educationEngine;
            _categoryEngine = categoryEngine;
            _educationContentEngine = educationContentEngine;
            _educationContentFileEngine = educationContentFileEngine;
        }

        public async Task<IActionResult> Index()
        {
            //AppUser user = _userManager.
            var user = await _userManager.GetUserAsync(User);  //  _userManager.GetUserAsync(User);
            return View(user);
        }

        public IActionResult MyEducationList()
        {
            var userId = Convert.ToInt32(_userManager.GetUserId(User));
            var dataList = _educationEngine.GetEducations(userId);
            return View(dataList);
        }

        public IActionResult TrainingsIAttended()
        {
            var userId = _userManager.GetUserId(User);
            var data = _educationEngine.TrainingsIAttended(Convert.ToInt32(userId), 0, 50);
            return View(data);
        }

        public IActionResult GetEducation(int id)
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.CategoryList = _categoryEngine.GetCategories();
            var data = _educationEngine.GetEducationsDetail(id,Convert.ToInt32(userId));
            if(data == null)
            {
                return RedirectToAction("Index","Home");
            }
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateEducation(EducationRequest model)
        {
            var userId = _userManager.GetUserId(User);
            model.UserId = Convert.ToInt32(userId);
            var response = _educationEngine.UpdateEducation(model);
            //TempData["StatusUpdate"] = response;
            return RedirectToAction("GetEducation", "Profile", new { id=model.Id});
        }

        public IActionResult CreateEducation()
        {
            ViewBag.CategoryList = _categoryEngine.GetCategories();
            return View();
        }

        [HttpPost]
        public IActionResult CreateEducation(EducationRequest model)
        {
            var userId = _userManager.GetUserId(User);
            model.UserId = Convert.ToInt32(userId);
            var data = _educationEngine.InsertEducation(model);
            return RedirectToAction("MyEducationList");
        }

        public IActionResult UpdateEducationContent(int id)
        {
            var data = _educationContentEngine.GetEducationContent(id);
            ViewBag.EducationResponse = _educationEngine.GetEducationsDetail(data.EducationId); 
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateEducationContent(EducationContentRequest model)
        {
            var userId = _userManager.GetUserId(User);
            var data = _educationContentEngine.UpdateEducationContent(model);
            ViewBag.EducationResponse = _educationEngine.GetEducationsDetail(data.EducationId);
            return View(data);
        }


        [HttpPost]
        public IActionResult CreateEducationContent(EducationContentRequest request)
        {
            var data = _educationContentEngine.InsertEducationContent(request);
            //return RedirectToAction("GetEducation", "Profile", new { id = request.EducationId });
            return RedirectToAction("UpdateEducationContent", "Profile", new { id = data.Id });
        }

        [HttpPost]
        public IActionResult CreateEducationContentFile(EducationContentFileRequest request, IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                //Hata
            }

            var extension = Path.GetExtension(file.FileName).Trim('.').ToLower();
            if (!new[] { "jpg", "png", "jpeg", "mp4" }.Contains(extension))
            {
                //Hata
            }
            Guid guid = Guid.NewGuid();
            var local_image_dir = $"wwwroot/_upload/file";
            var local_image_path = $"{local_image_dir}/{guid + file.FileName}";

            //dosya var mı
            if (!Directory.Exists(Path.Combine(local_image_dir)))
            {
                Directory.CreateDirectory(Path.Combine(local_image_dir));
            }

            using (Stream fileStream = new FileStream(local_image_path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            request.FileName = local_image_path.Replace("wwwroot/","");
            request.FileExtension = extension;

            var data = _educationContentFileEngine.InsertEducationContentFile(request);
            return RedirectToAction("UpdateEducationContent", "Profile", new { id = request.EducationContentId });
        }


        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(UpdatePasswordRequest request)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, request.OldPassword, request.NewPassword);

            if (!changePasswordResult.Succeeded)
            {
                ViewBag.StatusMessage = "Şifre Değiştirilemedi";
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            ViewBag.StatusMessage = "Şifre Değiştirildi";
            return View();


        }


    }
}
