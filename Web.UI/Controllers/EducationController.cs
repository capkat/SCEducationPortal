using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SCEducationPortal.Business.Commons.Models.EducationModels;
using SCEducationPortal.Business.Commons.Models.EducationUserModels;
using SCEducationPortal.Business.Commons.Models.UserModels;
using SCEducationPortal.Business.IEngines;
using SCEducationPortal.Data.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Controllers
{
    public class EducationController : Controller
    {


        private readonly ICategoryEngine _categoryEngine;
        private readonly IEducationEngine _educationEngine;
        private readonly IEducationUserEngine _educationUserEngine;
        private readonly ILogger<EducationController> _logger;

        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;

        public EducationController(SignInManager<AppUser> signInManager, ILogger<EducationController> logger, IEducationEngine educationEngine, UserManager<AppUser> userManager, ICategoryEngine categoryEngine, IEducationUserEngine educationUserEngine)

        {
            _logger = logger;
            _educationEngine = educationEngine;
            _userManager = userManager;
            _categoryEngine = categoryEngine;
            _signInManager = signInManager;
            _educationUserEngine = educationUserEngine;

        }

        public IActionResult Index(int? id, int? order)
        {
            int skip = 0;
            int take = 20;
            if (order != null)
            {
                skip = order.Value * take;
            }
            var dataList = new List<EducationResponse>();

            ViewBag.CategoryList = _categoryEngine.GetCategories();
            if (id != null && id > 0)
            {
                dataList = _educationEngine.GetEducations(skip, take, id.Value);
            }
            else
            {
                dataList = _educationEngine.GetEducations(skip, take);
            }

            return View(dataList);

        }

        public IActionResult Detail(int id, int? contentId)
        {
            if (_signInManager.IsSignedIn(User))
            {
                var userId = _userManager.GetUserId(User);
                var isRegisteredUser = _educationUserEngine.IsUserRegisteredEducation(new EducationUserRequest
                {
                    UserId = Convert.ToInt32(userId),
                    EducationId = id
                });

                if (isRegisteredUser)
                {
                    //Login Kayıtlı
                    ViewBag.UserEducationStatus = "LoginRegistered";
                }
                else
                {
                    //Login Kayıtsız
                    ViewBag.UserEducationStatus = "LoginNoRegistered";
                    ViewBag.CategoryList = _categoryEngine.GetCategories();
                }
            }
            else
            {
                //Login değil
                ViewBag.UserEducationStatus = "NoLogin";
                ViewBag.CategoryList = _categoryEngine.GetCategories();
            }

            var dataList = _educationEngine.GetEducationsDetail(id);

            if (dataList.EducationContents.Count() > 0)
            {
                var data = dataList.EducationContents.Where(c => c.Id == contentId).FirstOrDefault();
                if (data != null)
                {
                    ViewBag.ContentId = contentId;
                }
                else
                {
                    ViewBag.ContentId = dataList.EducationContents[0].Id;
                }
            }




            //ViewBag.content = dataList.EducationContents
            return View(dataList);
        }

        [HttpPost]
        public IActionResult CreateEducationUser(int id)
        {
            EducationUserRequest model = new EducationUserRequest();
            var userId = _userManager.GetUserId(User);
            model.UserId = Convert.ToInt32(userId);
            model.EducationId = id;
            var response = _educationUserEngine.CreateEducationUser(model);

            return RedirectToAction("Detail", "Education", new { id = response.EducationId });
        }

    }
}
