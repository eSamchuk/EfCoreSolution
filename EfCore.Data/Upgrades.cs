using System;
using System.Collections.Generic;

namespace EfCore.Data
{
    public partial class Upgrades
    {
        public Upgrades()
        {
            UpgradeBonuses = new HashSet<UpgradeBonuses>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int QualityId { get; set; }
        public int? StarShipId { get; set; }

        public virtual Constants Quality { get; set; }
        public virtual StarShips StarShip { get; set; }
        public virtual ICollection<UpgradeBonuses> UpgradeBonuses { get; set; }
    }
}
