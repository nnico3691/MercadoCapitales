using MercadoCapitales.API.Precios.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MercadoCapitales.API.Precios.Services
{
    public interface IInstrumentService
    {
        Task<List<InstrumentDto>> GetAllInstrumentsAsync();

        //Task<Instrument> GetInstrumentByIdAsync(string instrumentCode);

        //Task<Instrument> CreateInstrumentAsync(Instrument newInstrument);
        //Task<bool> UpdateInstrumentAsync(Instrument instrument);
        //Task<bool> DeleteInstrumentAsync(string instrumentCode);
        //Task<IEnumerable<Instrument>> SearchInstrumentsAsync(string searchTerm);
    }
}
