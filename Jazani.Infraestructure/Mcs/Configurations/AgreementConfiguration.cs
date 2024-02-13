using Jazani.Domain.Admins.Models;
using Jazani.Domain.Mcs.Models;
using Jazani.Infrastructure.Cores.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.Infrastructure.Mcs.Configurations
{
    public class AgreementConfiguration : IEntityTypeConfiguration<Agreement>
    {
        public void Configure(EntityTypeBuilder<Agreement> builder)
        {
            builder.ToTable("agreement", "mc");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.AgreementTypeId).HasColumnName("agreementtypeid");
            builder.Property(t => t.Name).HasColumnName("name");

            builder.Property(t => t.Description).HasColumnName("description");
            builder.Property(t => t.State).HasColumnName("state");
            
            //builder.Property(t => t.Contractid).HasColumnName("contractid");
            //builder.Property(t => t.Holderid).HasColumnName("holderid");

            builder.Property(t => t.RegistrationDate).HasColumnName("registrationdate")
                .HasConversion(new DateTimeToDateTimeOffset());

            // Relations
            builder.HasOne(a => a.AgreementType) // Entidad/Model
                .WithMany(at => at.Agreements)   // Entida/Model
                .HasForeignKey(a => a.AgreementTypeId);
        }
    }
}
