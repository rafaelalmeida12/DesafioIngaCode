using IngaCode.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IngaCode.Infrastructure.Mappings
{
    public class UserMap : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            //builder.Toble("User");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.UserName).HasMaxLength(100).IsUnicode();
        }
    }
}
