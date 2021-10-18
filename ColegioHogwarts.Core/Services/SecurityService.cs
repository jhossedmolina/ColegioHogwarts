using ColegioHogwarts.Core.DTOs;
using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Enumerations;
using ColegioHogwarts.Core.Exceptions;
using ColegioHogwarts.Core.Interfaces;
using System.Threading.Tasks;

namespace ColegioHogwarts.Core.Services
{
    public class SecurityService : ISecurityService
    {
        private IUnitOfWork _unitOfWork;

        public SecurityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Security> GetLoginByCredentials(UserLogin userLogin)
        {
            return await _unitOfWork.SecurityRepository.GetLoginByCredentials(userLogin);
        }

        public async Task RegisterUser(Security security)
        {
            if(RoleType.Administrador == security.Role)
            {
                await _unitOfWork.SecurityRepository.Add(security);
                await _unitOfWork.SaveChangesAsync();
            }
            else if(RoleType.Usuario == security.Role)
            {
                await _unitOfWork.SecurityRepository.Add(security);
                await _unitOfWork.SaveChangesAsync();
            }
            else
            {
                throw new GlobalException($"El Rol {security.Role} no existe. " +
                    "Solo puede ingresar 0 = Administrador o 1 = Usuario como tipo de Rol");
            }
            
        }
    }
}
