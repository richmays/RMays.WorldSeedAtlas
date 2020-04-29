using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.WorldSeedAtlas
{
    [Serializable]
    public class Location
    {
        public string Name { get; set; }
        public string BossName { get; set; }
        public string Type { get; set; }
        public string XCoord { get; set; }
        public string YCoord { get; set; }
    }
}
