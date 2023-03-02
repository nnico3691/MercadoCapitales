using System;

namespace AuthenticationWebApi.RemoteModel
{
    public class LoginRemote
    {
        public Guid? LoginId { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public Guid? Cliente { get; set; }
    }
}
