using EstudiesDocker.Entites.Vehicle.Enums;
using System.Collections;
using System.Security.Cryptography.Xml;

namespace EstudiesDocker.Entites.Vehicle
{
    public abstract class Vehicle
    {
        public Guid Id { get;init; }
        public string Name { get; init; }   
        public string Description { get; init; }
        public bool IsActive { get; protected set; }
        public Status Status { get; protected set; }
        public CreationMethod CreationMethod { get; init; }
        public string? LinkPhoto { get; protected set; }
        public string? FileName { get; protected set; } = string.Empty;
        //EF Constructor
        protected Vehicle()
        {
        }
        public void Finish()
        {
            if(!IsActive && ( Status != Status.Canceled || Status != Status.Finish))
                IsActive = true;     
        }

        public void AddLinkPhoto(string uriLink)
        {
            LinkPhoto = uriLink ?? "";
        }

        public void AddFileName(string fileName)
        {
            FileName = fileName ?? "";
        }
      
    }
}
