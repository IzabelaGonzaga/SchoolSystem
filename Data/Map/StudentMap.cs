using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Map
{
    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("nvarchar(100)")
                .IsRequired();

            builder.Property(x => x.Address)
                 .HasColumnType("nvarchar(250)")
                 .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();
        }
    }
}
