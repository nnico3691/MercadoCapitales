using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;
using MercadoCapitales.API.Clientes.Modelo;
using MercadoCapitales.API.Clientes.Persistencia;
using MercadoCapitales.API.Clientes.Aplicacion.Requests;

namespace MercadoCapitales.API.Clientes.Aplicacion
{
    public class CrearClientePerfilInversor
    {
        public class Ejecuta : IRequest
        {
            public Guid? Volumen_ingre { get; set; }
            public Guid? Obj_renta { get; set; }
            public Guid? tol_riesgo { get; set; }
            public Guid? hor_inv { get; set; }
            public Guid? entend_merc { get; set; }
            public Guid? exp_inversion_1 { get; set; }
            public Guid? exp_inversion_2 { get; set; }
            public Guid? exp_inversion_3 { get; set; }
            public Guid? exp_inversion_4 { get; set; }
            public Guid? exp_inversion_5 { get; set; }
            public Guid? exp_inversion_6 { get; set; }
            public Guid? ClienteId { get; set; }

        }

        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly ContextCliente _contexto;

            public Manejador(ContextCliente contexto)
            {
                _contexto = contexto;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var Volumen_ingreso = new ClientePerfilInversor
                {
                    ClienteId = request.ClienteId,
                    EncuestaRespuestaId = request.Volumen_ingre

                };
                _contexto.ClientePerfilInversor.Add(Volumen_ingreso);

                var Obj_renta = new ClientePerfilInversor
                {
                    ClienteId = request.ClienteId,
                    EncuestaRespuestaId = request.Obj_renta

                };
                _contexto.ClientePerfilInversor.Add(Obj_renta);

                var tol_riesgo = new ClientePerfilInversor
                {
                    ClienteId = request.ClienteId,
                    EncuestaRespuestaId = request.tol_riesgo

                };
                _contexto.ClientePerfilInversor.Add(tol_riesgo);

                var hor_inv = new ClientePerfilInversor
                {
                    ClienteId = request.ClienteId,
                    EncuestaRespuestaId = request.hor_inv

                };
                _contexto.ClientePerfilInversor.Add(hor_inv);

                var entend_merc = new ClientePerfilInversor
                {
                    ClienteId = request.ClienteId,
                    EncuestaRespuestaId = request.entend_merc

                };
                _contexto.ClientePerfilInversor.Add(entend_merc);

                string exp_inversion_1 = request.exp_inversion_2.ToString();

                if (exp_inversion_1 != string.Empty || exp_inversion_1 != "")
                {
                    var exp_inversion = new ClientePerfilInversor
                    {
                        ClienteId = request.ClienteId,
                        EncuestaRespuestaId = request.exp_inversion_1

                    };
                    _contexto.ClientePerfilInversor.Add(exp_inversion);
                }

                string exp_inversion_2 = request.exp_inversion_2.ToString();

                if (exp_inversion_2 != string.Empty || exp_inversion_2 != "")
                {
                    var exp_inversion = new ClientePerfilInversor
                    {
                        ClienteId = request.ClienteId,
                        EncuestaRespuestaId = request.exp_inversion_2

                    };
                    _contexto.ClientePerfilInversor.Add(exp_inversion);
                }

                string exp_inversion_3 = request.exp_inversion_3.ToString();

                if (exp_inversion_3 != string.Empty || exp_inversion_3 != "")
                {
                    var exp_inversion = new ClientePerfilInversor
                    {
                        ClienteId = request.ClienteId,
                        EncuestaRespuestaId = request.exp_inversion_3

                    };
                    _contexto.ClientePerfilInversor.Add(exp_inversion);
                }

                string exp_inversion_4 = request.exp_inversion_4.ToString();

                if (exp_inversion_4 != string.Empty || exp_inversion_4 != "")
                { 
                    var exp_inversion = new ClientePerfilInversor
                    {
                        ClienteId = request.ClienteId,
                        EncuestaRespuestaId = request.exp_inversion_4

                    };
                    _contexto.ClientePerfilInversor.Add(exp_inversion);
                }

                string exp_inversion_5 = request.exp_inversion_5.ToString();

                if (exp_inversion_5 != string.Empty || exp_inversion_5 != "")
                {
                    var exp_inversion = new ClientePerfilInversor
                    {
                        ClienteId = request.ClienteId,
                        EncuestaRespuestaId = request.exp_inversion_5

                    };
                    _contexto.ClientePerfilInversor.Add(exp_inversion);
                }

                string exp_inversion_6 = request.exp_inversion_6.ToString();

                if (exp_inversion_6 != string.Empty || exp_inversion_6 != "")
                {
                    var exp_inversion = new ClientePerfilInversor
                    {
                        ClienteId = request.ClienteId,
                        EncuestaRespuestaId = request.exp_inversion_1

                    };
                    _contexto.ClientePerfilInversor.Add(exp_inversion);
                }

                var value = await _contexto.SaveChangesAsync();

                if (value > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("Errores en la inserción del Nuevo Cliente");



            }
        }
    }
}
