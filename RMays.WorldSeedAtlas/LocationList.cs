using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMays.WorldSeedAtlas
{
    public class LocationList : ICollection<SmartLocation>
    {
        internal List<SmartLocation> Locations { get; set; }

        #region Interface Implementation: ICollection<Location>
        public int Count => Locations.Count;

        public bool IsReadOnly => false;

        public void Add(SmartLocation item)
        {
            Locations.Add(item);
        }

        public void Clear()
        {
            Locations.Clear();
        }

        public bool Contains(SmartLocation item)
        {
            return Locations.Contains(item);
        }

        public void CopyTo(SmartLocation[] array, int arrayIndex)
        {
            Locations.CopyTo(array, arrayIndex);
        }

        public IEnumerator<SmartLocation> GetEnumerator()
        {
            return Locations.GetEnumerator();
        }

        public bool Remove(SmartLocation item)
        {
            return Locations.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Locations.GetEnumerator();
        }
        #endregion

        public LocationList(string filename)
        {
            // Defines what the files looks like: a list of LocationTypes, and a list of Locations.
            var locationFileDefinition = new { LocationTypes = new List<string>(), Locations = new List<SmartLocation>() };

            // Read the entire file into a string.
            var locationFileContents = new StreamReader(filename).ReadToEnd();

            // Convert the string into a list of LocationTypes and Locations.
            var locationData = JsonConvert.DeserializeAnonymousType(locationFileContents, locationFileDefinition);

            Locations = new List<SmartLocation>();
            foreach(var location in locationData.Locations)
            {
                Locations.Add(location);
            }
        }

        public void SortLocations(string currentLocation)
        {
        }
    }
}
