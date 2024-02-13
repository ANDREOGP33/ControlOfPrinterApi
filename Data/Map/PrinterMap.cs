using ControlOfPrinterApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControlOfPrinterApi.Data.Map
{
    public class PrinterMap : IEntityTypeConfiguration<PrinterModel>
    {
        public void Configure(EntityTypeBuilder<PrinterModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Sector).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Ip).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Level).HasMaxLength(50);
            builder.Property(x=>x.Serial).IsRequired().HasMaxLength(100);
        }
    }
}
