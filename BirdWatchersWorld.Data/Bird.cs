using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Data
{
    public class Bird
    {
        [Key]
        public int BirdID { get; set; }
        [Required, Display(Name = "Bird Name")]
        public string Name { get; set; }
        [Required, Display(Name = "Main Color")]
        public string MainColor { get; set; }
        [Required, Display(Name = "Secondary Color")]
        public string SecondColor { get; set; }

        public virtual ICollection<Sighting> Sightings { get; set; }
        
        //public int Picture { get; set; }
        //public int Sound { get; set; }
    }
}
