using System;

namespace MercadoCapitales.API.Clientes.Modelo.Dto
{
    public class PrimaryUserDto
    {
        public Guid? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Account { get; set; }
    }
}
