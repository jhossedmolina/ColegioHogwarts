using ColegioHogwarts.Core.Entities;
using System.Threading.Tasks;

namespace ColegioHogwarts.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}