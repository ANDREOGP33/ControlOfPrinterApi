using ControlOfPrinterApi.Models;

namespace ControlOfPrinterApi.Repositories.Interfaces
{
    public interface IPrinterRepository
    {
        Task<List<PrinterModel>> GetPrinters();
        Task<PrinterModel> GetPrinter(int id);
        Task<PrinterModel> AddPrinter(PrinterModel printer);
        Task<PrinterModel> UpdatePrinter(PrinterModel printer, int id);
        Task<bool> Delete(int id);

    }
}
