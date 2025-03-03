﻿using identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace identity.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
      
             private readonly UserManager<User> _userManager;
       
        public UserController(UserManager<User> userManager)
        {
            _userManager = userManager;
          
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            if (user == null)
                return NotFound();
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                throw new Exception();
            return ok();
        }

        private IActionResult ok()
        {
            throw new NotImplementedException();
        }
    }
}
