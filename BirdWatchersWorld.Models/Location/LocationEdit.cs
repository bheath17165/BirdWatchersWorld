using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Models.Location
{
    public class LocationEdit
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Closest City")]
        public string ClosestCity { get; set; }
        public double North { get; set; }
        public double East { get; set; }
        public double South { get; set; }
        public double West { get; set; }
    }
}
