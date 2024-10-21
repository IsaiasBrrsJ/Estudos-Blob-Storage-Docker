using EstudiesDocker.Entites.Vehicle.Enums;

namespace EstudiesDocker.Entites.Vehicle
{
    public class VehicleManual : Vehicle
    {
        public string ManualChange { get; init; } = default!;
        public string simulacaoGit { get; init; } = default!;   
        public void Cancel()
        {
            if (Status == Status.Finish)
                throw new InvalidOperationException("Not possible do it this");


            Status = Status.Canceled;
        }

        public static class Factories
        {
            public static VehicleManual VehicleManual(Guid id, string name, string description, string manualChange)
            {
                return new VehicleManual
                {
                    Id = id,
                    Name = name,
                    Description = description,
                    IsActive = true,
                    Status = Status.Start,
                    ManualChange = manualChange
                   
                };
            }
        }
    }
}
