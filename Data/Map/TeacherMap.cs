using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Map
{
    public class TeacherMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teacher");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar(150)")
                .IsRequired();

            builder.Property(x => x.Email)
               .HasColumnType("varchar(100)")
               .IsRequired();
        }
    }
}
