using Hali.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hali.Repository.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Phone).IsRequired();
            builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            builder.Property(x => x.AddressDescription).IsRequired().HasMaxLength(100);

        }
    }
}
