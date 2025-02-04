using MercadoCapitales.API.Clientes.Models;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Clientes.Services
{
    public interface IEmailSenderService
    {
        Task SenderEmailAsync(MailRequest request);
    }
}
