using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.DevFreela.Core.Entities;

namespace WM.DevFreela.Infrastructure.Persistence.Configurations
{
    public class UserConfigurations : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasColumnType("NVARCHAR(200)");
            builder.Property(x => x.FullName).HasColumnType("NVARCHAR(200)");
            builder.HasMany(x => x.Skills).WithOne().HasForeignKey(x => x.SkillId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
