using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IAccountsService
    {
        Task Register(RegisterModel model);
        Task<LoginDto> Login(LoginModel model);
        Task Logout();
    }
}
