using ControlOfPrinterApi.Models;
using ControlOfPrinterApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlOfPrinterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrinterController : ControllerBase
    {
        private readonly IPrinterRepository _printerRepository;

        public PrinterController(IPrinterRepository printerRepository)
        {
            _printerRepository = printerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrinterModel>>> SearchForPrinters()
        {
            List<PrinterModel> printers =  await _printerRepository.GetPrinters();
            return Ok(printers);
        }

        [HttpPost]
        public async Task<ActionResult<PrinterModel>> Register([FromBody] PrinterModel printer)
        {
            PrinterModel model = await _printerRepository.AddPrinter(printer);

            return Ok(model);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PrinterModel>> Update([FromBody] PrinterModel printerModel, int id)
        {
            printerModel.Id = id;
            PrinterModel model = await _printerRepository.UpdatePrinter(printerModel,id);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PrinterModel>> Delete(int id)
        {
            bool deleted = await _printerRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
