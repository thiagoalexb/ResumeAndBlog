using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.Configurations.Config;
using Resume.Data.Entities;

namespace Resume.Data.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>, IConfiguring
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(c => c.Id);

            builder.Property(c => c.Content)
                .HasColumnType("varchar(max)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.Title)
                .HasColumnType("varchar(200)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.SubTitle)
                .HasColumnType("varchar(500)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.MainImage)
                .HasColumnType("varchar(150)")
                .HasMaxLength(50);

            builder.Property(c => c.PublicationDate)
                .IsRequired();

            builder.Property(c => c.CreationDate)
                .IsRequired();

            builder.HasOne(x => x.User);

            builder.Property(c => c.Deleted);
        }
    }
}
