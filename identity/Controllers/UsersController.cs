using identity.Models;
using identity.viewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        public UsersController(UserManager<User> userManager, RoleManager<IdentityRole> RoleManager)
        {
            _userManager = userManager;
            _RoleManager = RoleManager;
        }

        public async Task<IActionResult> Index()
        {

            var users = await _userManager.Users.Select(user => new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Roles = _userManager.GetRolesAsync(user).Result
            }

                ).ToListAsync();
            return View(users);
        }
        public async Task<IActionResult> Add()
        {
            var roles = await _RoleManager.Roles.Select(r=>new RoleViewModel {RoleId=r.Id,RoleName=r.Name }).ToListAsync();
            var viewModel = new AddUserViewModel
            {
               
                Roles = roles
                
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(AddUserViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            if (!model.Roles.Any(r => r.IsSelected))
            {
                ModelState.AddModelError("Roles", "please choose Aleast one Role ");
                return View(model);
            }
            if(await _userManager.FindByEmailAsync(model.Email) != null)
            {
                ModelState.AddModelError("Email", "Email Is Already Exist");
                return View(model);
            }
            if (await _userManager.FindByNameAsync(model.User_Name) != null)
            {
                ModelState.AddModelError("User_Name", "User_Name Is Already Exist");
                return View(model);
            }
            var user = new User
            {
                UserName = model.User_Name,

                Email = model.Email,
                Phone = model.phone_number,
                Id_National = model.National_Id,
                FirstName = model.FirstName,
                LastName = model.LasttName
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Roles", error.Description);
                }
                return View(model);
            }
            await _userManager.AddToRolesAsync(user, model.Roles.Where(r => r.IsSelected).Select(r => r.RoleName));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();
           
            var viewModel = new ProfileViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
               


            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProfileViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var user = await _userManager.FindByIdAsync(model.Id);
            if (user == null)
                return NotFound();
            var userWithSameEmail = await _userManager.FindByEmailAsync(model.Email);
            if(userWithSameEmail !=null && userWithSameEmail.Id != model.Id)
            {
                ModelState.AddModelError("Email", "This Email is already assiged to another user");
                return View(model);
            }
            var userWithSameName = await _userManager.FindByNameAsync(model.User_Name);
            if (userWithSameName != null && userWithSameName.Id != model.Id)
            {
                ModelState.AddModelError("UserName", "This UserName is already assiged to another user");
                return View(model);
            }
            user.FirstName = model.FirstName;
            user.LastName = model.LasttName;
            user.UserName = model.User_Name;
            user.Email = model.Email;
            user.Phone = model.phone_number;
            user.Id_National = model.National_Id;


            await _userManager.UpdateAsync(user);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ManageRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return NotFound();
            var roles = await _RoleManager.Roles.ToListAsync();
            var viewModel = new UserRole
            {
                UserId = user.Id,
                UserName = user.UserName,
                Roles = roles.Select(role => new RoleViewModel { 
                RoleId=role.Id,
                RoleName=role.Name,
                IsSelected=_userManager.IsInRoleAsync(user,role.Name).Result
                }).ToList()

            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageRoles(UserRole model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
                return NotFound();
            var UserRoles = await _userManager.GetRolesAsync(user);
            foreach (var role in model.Roles)
            {
                if (UserRoles.Any(r => r == role.RoleName && !role.IsSelected))
                    await _userManager.RemoveFromRoleAsync(user, role.RoleName);

                if (!UserRoles.Any(r => r == role.RoleName && role.IsSelected))
                    await _userManager.AddToRoleAsync(user, role.RoleName);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
