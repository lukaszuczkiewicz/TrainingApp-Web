using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Mappings
{
    public class RunnerMapping : IEntityTypeConfiguration<Runner>
    {
        public void Configure(EntityTypeBuilder<Runner> builder)
        {
            builder.ToTable("Runners", schema: "Core");

            builder.HasKey(r => r.Id)
                .ForSqlServerIsClustered(false);

            builder.Property(r => r.Id)
                .ValueGeneratedNever();

            builder.OwnsOne<Email>(c => c.Email)
                .Property(x => x.EmailAdress)
                .HasColumnName("Email")
                .IsRequired();
        }
    }
}
