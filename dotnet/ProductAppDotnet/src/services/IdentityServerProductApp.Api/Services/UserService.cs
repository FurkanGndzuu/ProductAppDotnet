using IdentityServerProductApp.Api.Abstractions;
using IdentityServerProductApp.Api.Dtos;
using IdentityServerProductApp.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityServerProductApp.Api.Services
{
    public class UserService : IUserService
    {
       private readonly UserManager<ApplicationUser> _userManager;
       private readonly SignInManager<ApplicationUser> _signInManager;

        private readonly IHttpContextAccessor _contextAccessor;

        public UserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IHttpContextAccessor contextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> SignUpAsync(SignUpDto signup)
        {
            if(signup != null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = signup.UserName,
                    City = signup.City,
                    Email = signup.Email,
                };

              IdentityResult result =  await _userManager.CreateAsync(user ,  signup.Password);

                if(!result.Succeeded)
                {
                    //throw new System.Exception();
                    return false;
                }
                return true;

            }
            return false;
        }

        public async Task<GetUserDto> GetUserAsync()
        {
            string userId = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "sub").Value;
            if (userId == null) throw new System.Exception();

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null) throw new System.Exception();

            GetUserDto userDto = new GetUserDto()
            {
                city = user.City, email = user.Email,username = user.UserName,
            };
            return userDto;
        }
    }
}
