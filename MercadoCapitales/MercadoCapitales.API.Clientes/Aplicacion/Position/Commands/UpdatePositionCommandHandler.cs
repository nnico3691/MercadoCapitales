using MediatR;
using System.Threading.Tasks;
using System.Threading;
using MercadoCapitales.API.Clientes.Persistencia;

namespace MercadoCapitales.API.Clientes.Aplicacion.Position.Commands
{
    public class UpdatePositionCommandHandler : IRequestHandler<UpdatePositionCommand, bool>
    {
        private readonly ContextCliente _context;

        public UpdatePositionCommandHandler(ContextCliente context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdatePositionCommand request, CancellationToken cancellationToken)
        {
            var position = await _context.Position.FindAsync(request.Id);

            if (position == null) return false;

            position.InstrumentId = request.InstrumentId;
            position.Symbol = request.Symbol;
            position.BuySize = request.BuySize;
            position.BuyPrice = request.BuyPrice;
            position.SellSize = request.SellSize;
            position.SellPrice = request.SellPrice;
            position.TotalDailyDiff = request.TotalDailyDiff;
            position.TotalDiff = request.TotalDiff;
            position.TradingSymbol = request.TradingSymbol;

            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }

}
