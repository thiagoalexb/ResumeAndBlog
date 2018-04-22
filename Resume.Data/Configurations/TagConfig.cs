using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.Configurations.Config;
using Resume.Data.Entities;

namespace Resume.Data.Configurations
{
    public class TagConfig : IEntityTypeConfiguration<Tag>, IConfiguring
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(c => c.Id);

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.CreationDate)
                .IsRequired();

            builder.Property(c => c.Deleted);
        }
    }
}
