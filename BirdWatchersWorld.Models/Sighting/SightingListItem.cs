using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Models.Sighting
{
    public class SightingListItem
    {
        public int SightingID { get; set; }
        [Required, Display(Name = "Time Seen")]
        public DateTimeOffset TimeSeen { get; set; }
    }
}
