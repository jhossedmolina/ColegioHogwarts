using ColegioHogwarts.Core.Interfaces;
using ColegioHogwarts.Infraestructure.Options;
using Microsoft.Extensions.Options;
using System;
using System.Security.Cryptography;

namespace ColegioHogwarts.Infraestructure.Services
{
    public class PasswordService : IPasswordService
    {
        private readonly PasswordOptions _options;
        public PasswordService(IOptions<PasswordOptions> options)
        {
            _options = options.Value;
        }

        public bool Check(string hash, string password)
        {
            throw new System.NotImplementedException();
        }

        public string Hash(string password)
        {
            //PBKDF2 Implementation
            using (var algorithm = new Rfc2898DeriveBytes(
                password,
                _options.SaltSize,
                _options.Iterations))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(_options.KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{_options.Iterations}.{salt}.{key}";
            }
                
        }
    }
}
