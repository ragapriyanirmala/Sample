using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sample.Datahub.Repository;
using Sample.Services.DTOs;
using Sample.Services.Interfaces;

namespace Sample.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;
        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
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
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO input)
        {
            var user = await _userManager.FindByEmailAsync(input.UserName);
            if (user != null)
            {
                var result = await _userManager.CheckPasswordAsync(user, input.Password);
                if (result)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    if (roles != null)
                    {
                        var jwttoken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                        var response = new LoginResponseDTO { JwtToken = jwttoken };
                        return Ok(response);
                    }
                }
            }
            return BadRequest("User Name or Password are incorrect");
        }
    }
}
