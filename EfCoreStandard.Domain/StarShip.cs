using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreStandard.Domain
{
    public class StarShip
    {
        public StarShip()
        {
            this.Upgrades = new List<Upgrade>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public Constant Class { get; set; }
        public DateTime ObtainedDate { get; set; }
        public int StorageCapacity { get; set; }
        public int TechCapacity { get; set; }
        public double DamagePotential { get; set; }
        public double ShieldStrength { get; set; }
        public double HyperDriveDistance { get; set; }
        public double Maneuverability { get; set; }
        public int Cost { get; set; }
        public virtual List<Upgrade> Upgrades { get; set; }
        public virtual List<HangarStarship> ParkingHistory { get; set; }
    }
}
