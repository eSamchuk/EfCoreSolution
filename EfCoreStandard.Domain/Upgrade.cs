using System.Collections.Generic;

namespace EfCoreStandard.Domain
{
    public class Upgrade
    {
        public Upgrade()
        {
            this.Bonuses = new List<UpgradeBonus>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public List<UpgradeBonus> Bonuses { get; set; }

        public int QualityId { get; set; }

        public Constant Quality { get; set; }

        public int StarShipId { get; set; }

        public StarShip StarShip { get; set; }
    }
}