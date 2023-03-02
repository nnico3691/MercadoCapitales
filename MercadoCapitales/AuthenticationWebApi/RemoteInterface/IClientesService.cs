using AuthenticationWebApi.RemoteModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationWebApi.RemoteInterface
{
    public interface IClientesService
    {
       public Task<(bool resultado, LoginRemote Info, string ErrorMessage)> ValidarLogin(string Usuario, string Clave);
    }
}
