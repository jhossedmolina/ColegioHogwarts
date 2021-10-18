using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Interfaces;
using ColegioHogwarts.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ColegioHogwarts.Infraestructure.Repositories
{
    class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(ColegioHogwartsDBContext context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.UserSecurity == login.User &&
                                                       x.PasswordUser == login.Password);
        }
    }
}
