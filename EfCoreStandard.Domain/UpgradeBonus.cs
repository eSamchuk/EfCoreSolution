namespace EfCoreStandard.Domain
{
    public class UpgradeBonus
    {
        public int Id { get; set; }

        public int UpgradeId { get; set; }
        public Upgrade Upgrade { get; set; }

        public int TargetParameterId { get; set; }
        public Constant TargetParameter { get; set; }

        public double Value { get; set; }
    }
}