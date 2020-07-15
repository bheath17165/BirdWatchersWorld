using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Models.Sighting
{
    public class SightingCreate
    {
        [Required, Display(Name = "Time Seen")]
        public DateTimeOffset TimeSeen { get; set; }

        public int BirdID { get; set; }

        //public int LocationID { get; set; }
    }
}
