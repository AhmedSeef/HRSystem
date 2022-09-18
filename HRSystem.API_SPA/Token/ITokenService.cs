using HRSystem.Model;

namespace HRSystem.API_SPA.Token
{
    public interface ITokenService
    {
        string GetToken(Employee employee);
    }
}
