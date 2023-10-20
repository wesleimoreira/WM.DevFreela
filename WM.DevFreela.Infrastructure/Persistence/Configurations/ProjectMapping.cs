using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WM.DevFreela.Core.Entities;

namespace WM.DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.ToTable("Projects");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).HasColumnType("NVARCHAR(100)");
            builder.Property(x => x.TotalCost).HasColumnType("DECIMAL(10.2)");
            builder.Property(x => x.Description).HasColumnType("NVARCHAR(500)");
            builder.HasOne(x => x.Cliente).WithMany(x => x.OwnedProjects).HasForeignKey(x => x.ClienteId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Freelancer).WithMany(x => x.FreelanceProjects).HasForeignKey(x => x.FreelancerId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
