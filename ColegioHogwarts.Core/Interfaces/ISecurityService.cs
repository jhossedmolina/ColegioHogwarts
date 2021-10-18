using ColegioHogwarts.Core.Entities;
using System.Threading.Tasks;

namespace ColegioHogwarts.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}