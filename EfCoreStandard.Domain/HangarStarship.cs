using System;
using System.Collections.Generic;
using System.Text;

namespace EfCoreStandard.Domain
{
    public class HangarStarship
    {
        public int Id { get; set; }
        public int HangarId { get; set; }
        public Hangar Hangar { get; set; }
        public int StarshipId { get; set; }
        public StarShip Starship { get; set; }

        public DateTime Arrival { get; set; }
        public DateTime Departure { get; set; }

    }
}
