namespace EstudiesDocker.Entites.Vehicle
{
    public class VehiclePlanned : Vehicle
    {

        public void SetDate()
        {
            Status = Enums.Status.Canceled;
         }
            
        public static class Factories
        {
            public static VehiclePlanned AddVehiclePlanned(string name, string description)
            {
                return new VehiclePlanned { 
                 Id = Guid.NewGuid(),
                 Name = name,
                 Description = description,
                 IsActive = true,
                 Status = Enums.Status.Start,
                };  
            }
        }
    }
}
