using AuthenticationWebApi.RemoteInterface;
using AuthenticationWebApi.RemoteService;
using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;

namespace AuthenticationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly JwtTokenHandler _jwtTokenHandler;
        private readonly IClientesService _clientesService;

        public AccountController(JwtTokenHandler jwtTokenHandler, IClientesService clientesService)
        {
            _jwtTokenHandler = jwtTokenHandler;
            _clientesService = clientesService;
        }

        [HttpPost]
        [Route("Authenticate")]
        public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest authenticationRequest) 
        {
            try
            {
                if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) || string.IsNullOrWhiteSpace(authenticationRequest.Password))
                    return null;

                var cliente = _clientesService.ValidarLogin(authenticationRequest.UserName, authenticationRequest.Password);
                if (cliente.Result.resultado == false) return Unauthorized();

                /*Validation*/
                var userAccount = new UserAccount
                {
                    UserName = authenticationRequest.UserName,
                    Password = authenticationRequest.Password,
                    Role = "Administrator"
                };

                var authenticationResponse = _jwtTokenHandler.GenerateJwtToken(authenticationRequest, userAccount);
                if (authenticationResponse == null) return Unauthorized();

                return authenticationResponse;
            }
            catch(Exception ex) 
            {
                throw new Exception("ERROR: " + ex.Message);
            }

            
        }
    }
}
