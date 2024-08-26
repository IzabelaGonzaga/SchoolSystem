using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Map
{
    internal class RegisterMap : IEntityTypeConfiguration<Register>
    {
        public void Configure(EntityTypeBuilder<Register> builder)
        {
            builder.ToTable("Register");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.RegisterDate)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.HasOne(t => t.Student)
                .WithMany(tp => tp.Registers)
                .HasForeignKey(t => t.StudentId);

            builder.HasOne(t => t.Class)
                .WithMany(tp => tp.Registers)
                .HasForeignKey(i => i.ClassId);
        }
    }
}
