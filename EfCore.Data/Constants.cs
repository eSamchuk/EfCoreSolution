using System;
using System.Collections.Generic;

namespace EfCore.Data
{
    public partial class Constants
    {
        public Constants()
        {
            StarShips = new HashSet<StarShips>();
            UpgradeBonuses = new HashSet<UpgradeBonuses>();
            Upgrades = new HashSet<Upgrades>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public virtual ICollection<StarShips> StarShips { get; set; }
        public virtual ICollection<UpgradeBonuses> UpgradeBonuses { get; set; }
        public virtual ICollection<Upgrades> Upgrades { get; set; }
    }
}
