using IdentityServerProductApp.Api.Dtos;
using System.Threading.Tasks;

namespace IdentityServerProductApp.Api.Abstractions
{
    public interface IUserService
    {
        Task<bool> SignUpAsync(SignUpDto signup);
        Task<GetUserDto> GetUserAsync();
    }
}
