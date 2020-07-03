using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Data
{
    public class Spotter
    {
        [Key]
        public int SpotterID { get; set; }
        [Required, Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required, Display(Name="Last Name")]
        public string LastName { get; set; }
        [Display(Name="Full Name")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public virtual ICollection<Sighting> Sightings { get; set; }
    }
}
