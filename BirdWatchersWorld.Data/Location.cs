using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Data
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }
        [Required, Display(Name = "Location Name")]
        public string Name { get; set; }
        [Required, Display(Name = "Closest City")]
        public string ClosestCity { get; set; }
        [Required, Display(Name = "North Coordinate")]
        public double North { get; set; }
        [Required, Display(Name = "East Coordinate")]
        public double East { get; set; }
        [Required, Display(Name = "South Coordinate")]
        public double South { get; set; }
        [Required, Display(Name = "West Coordinate")]
        public double West { get; set; }

        public virtual ICollection<Sighting> Sightings { get; set; } = new List<Sighting>();
    }
}
