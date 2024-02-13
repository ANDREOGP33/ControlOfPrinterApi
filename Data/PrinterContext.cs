using ControlOfPrinterApi.Data.Map;
using ControlOfPrinterApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlOfPrinterApi.Data
{
    public class PrinterContext : DbContext
    {
        public PrinterContext(DbContextOptions<PrinterContext> options) : base(options)
        {         
        }

        public DbSet<PrinterModel> Printers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PrinterMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
