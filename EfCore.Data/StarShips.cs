using System;
using System.Collections.Generic;

namespace EfCore.Data
{
    public partial class StarShips
    {
        public StarShips()
        {
            Upgrades = new HashSet<Upgrades>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public DateTime ObtainedDate { get; set; }
        public int StorageCapacity { get; set; }
        public int TechCapacity { get; set; }
        public double DamagePotential { get; set; }
        public double ShieldStrength { get; set; }
        public double HyperDriveDistance { get; set; }
        public double Maneuverability { get; set; }
        public int Cost { get; set; }

        public virtual Constants Class { get; set; }
        public virtual ICollection<Upgrades> Upgrades { get; set; }
    }
}
