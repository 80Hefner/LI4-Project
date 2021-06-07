using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireSafe.Models
{
    public class FireLocation
    {
        public int LocationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public FireLocation(int locid, string title, string desc, string latitude, string longitude)
        {
            this.LocationId = locid;
            this.Title = title;
            this.Description = desc;
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }


    public class LocationLists
    {
        public IEnumerable<FireLocation> FireLocationList { get; set; }
    }
}
