using Hali.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hali.Repository.Configurations
{
    public class ProcessOrderConfigurion : IEntityTypeConfiguration<ProcessOrder>
    {
        public void Configure(EntityTypeBuilder<ProcessOrder> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Order).WithMany(x => x.ProcessOrders).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Process).WithMany(x => x.ProcessOrders).HasForeignKey(x => x.ProcessId);
        }
    }
}
