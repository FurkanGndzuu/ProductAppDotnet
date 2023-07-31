using IdentityServerProductApp.Api.Abstractions;
using IdentityServerProductApp.Api.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServerProductApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDto signup) => Ok(await _userService.SignUpAsync(signup));

        [HttpGet]
        public async Task<IActionResult> GetUser() => Ok(await _userService.GetUserAsync());
    }
}
