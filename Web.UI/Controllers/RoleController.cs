using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SCEducationPortal.Business.Commons.Models.RoleModels;
using SCEducationPortal.Data.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.UI.Controllers
{
    [Authorize()]
    public class RoleController : Controller
    {
        readonly RoleManager<AppRole> _roleManager;
        readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole(string id)
        {
            if (id != null)
            {
                AppRole role = await _roleManager.FindByIdAsync(id);

                return View(new CreateRoleRequest
                {
                    Name = role.Name,
                });
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleRequest model, string id)
        {
            IdentityResult result = null;
            if (id != null)
            {
                AppRole role = await _roleManager.FindByIdAsync(id);
                role.Name = model.Name;
                result = await _roleManager.UpdateAsync(role);
            }
            else
                result = await _roleManager.CreateAsync(new AppRole { Name = model.Name, CreateDate = DateTime.Now });

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RoleAssign(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            List<AppRole> allRoles = _roleManager.Roles.ToList();
            List<string> userRoles = await _userManager.GetRolesAsync(user) as List<string>;
            List<RoleAssignRequest> assignRoles = new List<RoleAssignRequest>();
            allRoles.ForEach(role => assignRoles.Add(new RoleAssignRequest
            {
                HasAssign = userRoles.Contains(role.Name),
                RoleId = role.Id,
                RoleName = role.Name
            }));

            return View(assignRoles);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult> RoleAssign(List<RoleAssignRequest> modelList, string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            foreach (RoleAssignRequest role in modelList)
            {
                if (role.HasAssign)
                    await _userManager.AddToRoleAsync(user, role.RoleName);
                else
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);
            }
            return RedirectToAction("RoleAssign", "Role",new { id=id});
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string id)
        {
            AppRole role = await _roleManager.FindByIdAsync(id);
            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                //Başarılı...
            }
            return RedirectToAction("Index");
        }

    }
}
