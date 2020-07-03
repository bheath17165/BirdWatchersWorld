using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace BirdWatchersWorld.Models.Sighting
{
    public class SightingEdit
    {
        public int SightingID { get; set; }
        [Display(Name = "Time Seen")]
        public DateTimeOffset TimeSeen { get; set; }
    }
}
