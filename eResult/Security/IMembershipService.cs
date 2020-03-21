using IIT.EResult.Security.Models;

namespace IIT.EResult.Security
{
    public interface IMembershipService
    {
        AuthStatus ValidateUser(string userName, string password);
        string[] GetRoles(string userName);
    }
}
