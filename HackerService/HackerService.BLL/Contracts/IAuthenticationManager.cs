using System.Threading.Tasks;
using HackerService.BLL.DTO;

namespace HackerService.BLL.Contracts
{
    public interface IAuthenticationManager
    {

            Task<bool> ValidateUser(UserForAuthenticationDto userForAuth);
            Task<string> CreateToken();
    }
    
}
