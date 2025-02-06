using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sample.Services.DTOs;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly UserManager<IdentityUser> _userManager;
        public AuthController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO input)
        {
            var identityuser = new IdentityUser
            {
                UserName = input.UserName,
                Email = input.UserName
            };
            var identityresult = await _userManager.CreateAsync(identityuser, input.Password);
            if (identityresult.Succeeded)
            {
                if (input.Roles != null && input.Roles.Any())
                {
                    identityresult = await _userManager.AddToRolesAsync(identityuser, input.Roles);
                    if (identityresult.Succeeded)
                    {
                        return Ok("User was Registered");
                    }
                }
            }
            return BadRequest("Something Went Wrong");
        }
    }
}
