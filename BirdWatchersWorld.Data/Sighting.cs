using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Data
{
    public class Sighting
    {
        [Key]
        public int SightingID { get; set; }
        [Required, Display(Name = "Time Seen")]
        public DateTimeOffset TimeSeen { get; set; }

        [ForeignKey("Spotter")]
        public int SpotterID { get; set; }
        public virtual Spotter Spotter { get; set; }

        [ForeignKey("Bird")]
        public int BirdID { get; set; }
        public virtual Bird Bird { get; set; }

        [ForeignKey("Location")]
        public int LocationID { get; set; }
        public virtual Location Location { get; set; }
    }
}
