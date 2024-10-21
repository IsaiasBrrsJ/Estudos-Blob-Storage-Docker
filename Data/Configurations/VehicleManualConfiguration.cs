using EstudiesDocker.Entites.Vehicle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstudiesDocker.Data.Configurations
{
    public class VehicleManualConfiguration : IEntityTypeConfiguration<VehicleManual>
    {
        public void Configure(EntityTypeBuilder<VehicleManual> builder)
        {

            builder.Property(x => x.ManualChange)
                 .HasColumnType("varchar(40)");

        }
    }
}
