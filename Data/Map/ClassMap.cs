using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Map
{
    public class ClassMap : IEntityTypeConfiguration<Class>
    {
        public void Configure(EntityTypeBuilder<Class> builder)
        {
            builder.ToTable("Class");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                .HasColumnType("nvarchar(150)")
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("nvarchar(300)");

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.StartDate)
                .IsRequired();
        }
    }
}
