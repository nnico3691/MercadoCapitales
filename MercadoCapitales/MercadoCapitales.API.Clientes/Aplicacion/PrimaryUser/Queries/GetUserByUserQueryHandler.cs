using MediatR;
using MercadoCapitales.API.Clientes.Modelo.Dto;
using MercadoCapitales.API.Clientes.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Clientes.Aplicacion.PrimaryUser.Queries
{
    public class GetUserByUserQueryHandler : IRequestHandler<GetUserByUserQuery, PrimaryUserDto>
    {

        private readonly ContextCliente _context;
        public GetUserByUserQueryHandler(ContextCliente contextCliente)
        {
            _context = contextCliente;
        }

        public async Task<PrimaryUserDto> Handle(GetUserByUserQuery query, CancellationToken cancellationToken) 
        {
            try
            {
                // Buscar el usuario en la base de datos usando el contexto
                var user = await _context.PrimaryUser
                    .FirstOrDefaultAsync(u => u.Username == query.UserName, cancellationToken);

                // Validar si se encontró el usuario
                if (user == null)
                {
                    throw new Exception($"Usuario con nombre de usuario '{query.UserName}' no encontrado.");
                }

                var PrimaryUserDto = new PrimaryUserDto
                {
                    UserName = user.Username,
                    Password = user.Password,
                    Account  = user.Account,
                };

                // Si se encuentra, devolver el usuario
                return PrimaryUserDto;

            }
            catch (DbUpdateException dbEx)
            {
                // Manejar excepciones relacionadas con la base de datos
                // Por ejemplo, puedes registrar el error o lanzar una excepción personalizada
                throw new Exception("Error al actualizar la base de datos: " + dbEx.Message, dbEx);
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones generales
                throw new Exception("Ocurrió un error inesperado: " + ex.Message, ex);
            }


        }
    }
}
