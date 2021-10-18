﻿using ColegioHogwarts.Core.Entities;
using ColegioHogwarts.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ColegioHogwarts.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ISecurityService _securityService;

        public TokenController(IConfiguration configuration, ISecurityService securityService)
        {
            _configuration = configuration;
            _securityService = securityService;
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(UserLogin login)
        {
            //If it is a valid user
            var validation = await IsValidUser(login);
            if(validation.Item1)
            {
                var token = generateToken(validation.Item2);
                return Ok(new { token });
            }

            return NotFound();
        }

        private async Task<(bool, Security)> IsValidUser(UserLogin login)
        {
            var user = await _securityService.GetLoginByCredentials(login);
            return (user != null, user);
        }

        private string generateToken(Security security)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, security.UserName),
                new Claim("User", security.UserSecurity),
                new Claim(ClaimTypes.Role, security.RoleUser.ToString()),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(10)
            );

            var token = new JwtSecurityToken(header, payload);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
