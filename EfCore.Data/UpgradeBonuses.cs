using System;
using System.Collections.Generic;

namespace EfCore.Data
{
    public partial class UpgradeBonuses
    {
        public int Id { get; set; }
        public int TargetParameterId { get; set; }
        public double Value { get; set; }
        public int? UpgradeId { get; set; }

        public virtual Constants TargetParameter { get; set; }
        public virtual Upgrades Upgrade { get; set; }
    }
}
