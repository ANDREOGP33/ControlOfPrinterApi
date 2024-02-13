using ControlOfPrinterApi.Data;
using ControlOfPrinterApi.Models;
using ControlOfPrinterApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlOfPrinterApi.Repositories
{
    public class PrinterRepository : IPrinterRepository
    {
        private readonly PrinterContext _context;
        public PrinterRepository(PrinterContext context)
        {
            _context = context;
        }
        public async Task<PrinterModel> GetPrinter(int id)
        {
            return await _context.Printers.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<PrinterModel>> GetPrinters()
        {
            return await _context.Printers.ToListAsync();
        }

        public async Task<PrinterModel> AddPrinter(PrinterModel printer)
        {
            await _context.Printers.AddAsync(printer);
            await _context.SaveChangesAsync();
            return printer;
        }

        public async Task<bool> Delete(int id)
        {
            PrinterModel model = await GetPrinter(id);
            if (model == null)
            {
                throw new Exception($"Impressora para o ID: {id} não foi encontrada no banco de dados.");
            }

            _context.Printers.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PrinterModel> UpdatePrinter(PrinterModel printer, int id)
        {
            PrinterModel model = await GetPrinter(id);
            if (model == null)
            {
                throw new Exception($"Impressora para o ID: {id} não foi encontrada no banco de dados.");
            }

            
            model.Sector = printer.Sector;
            model.Ip = printer.Ip;
            model.Serial = printer.Serial;

            _context.Printers.Update(model);
            await _context.SaveChangesAsync();

            return model;
        }

    }
}
