using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Resume.Data.Configurations.Config;
using Resume.Data.Entities;

namespace Resume.Data.Configurations
{
    public class PostTagConfig : IEntityTypeConfiguration<PostTag>, IConfiguring
    {
        public void Configure(EntityTypeBuilder<PostTag> builder)
        {
            builder.HasKey(x => new { x.PostId, x.TagId });
        }
    }
}
