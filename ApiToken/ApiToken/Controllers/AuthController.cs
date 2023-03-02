﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace ApiToken.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public AuthController(ILogger<AuthController> logger, IConfiguration config)
        {
            configuration = config;
        }

        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Token(Credentials credentials)
        {
            if (!IsAdmin(credentials) && !IsUser(credentials))
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(credentials.secretKey));
      
            var jwt = new JwtSecurityToken(
                claims: BuildClaims(credentials),
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512)
                );

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return Ok(token);

        }

        private IEnumerable<Claim> BuildClaims(Credentials credentials)
        {
            return new[]
            {
                new Claim("userType", IsAdmin(credentials) ? "admin" : "user")
            };
        }

        private bool IsAdmin(Credentials credentials)
        {
            return credentials.UserName == "admin";
        }

        private bool IsUser(Credentials credentials)
        {
            return credentials.UserName == "user";
        }

    }
}
