using EstudiesDocker.Entites.Vehicle;
using EstudiesDocker.Entites.Vehicle.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EstudiesDocker.Data.Configurations
{
    public class VehicleConfigurations : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {

            builder.ToTable("Vehicles");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
            .IsRequired()
                .ValueGeneratedNever();

            builder.Property(x => x.Status)
                .HasConversion<string>()
                .IsRequired()
                .HasColumnType("varchar(50)");

            

            builder
                .HasIndex(x => x.Name);

            builder.Property(x => x.CreationMethod)
                .IsRequired()
                .HasConversion<string>()
                .HasColumnType("varchar(50)");


            builder.HasDiscriminator<CreationMethod>("CreationMethod")
                .HasValue<VehicleManual>(CreationMethod.Manual)
                .HasValue<VehiclePlanned>(CreationMethod.Planned);

            //docker run -d -p 10000:10000 mcr.microsoft.com/azure-storage/azurite azurite-blob --blobHost 0.0.0.0

        }

    }
}
