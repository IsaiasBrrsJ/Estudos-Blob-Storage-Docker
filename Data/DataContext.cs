using EstudiesDocker.Entites.Vehicle;
using EstudiesDocker.Entites.Vehicle.Enums;
using Microsoft.EntityFrameworkCore;

namespace EstudiesDocker.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> @base) :base(@base) { }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var type in modelBuilder.Model.GetEntityTypes().SelectMany(prop =>
                prop.GetProperties().Where(x => x.ClrType == typeof(string))))
                type.SetColumnType("varchar(100)");


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);



            base.OnModelCreating(modelBuilder); 
         
        }

        

    }

}
