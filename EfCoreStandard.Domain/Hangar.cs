using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreStandard.Domain
{
    public class Hangar
    {
        public int Id { get; set; }
        public virtual List<HangarStarship> ShipsParkingHistory { get; set; }

    }
}
