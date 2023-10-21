using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.DevFreela.Core.Entities;

namespace WM.DevFreela.Infrastructure.Persistence.Configurations
{
    public class SkillConfigurations : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.ToTable("Skills");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description).HasColumnType("NVARCHAR(500)");
        }
    }
}
