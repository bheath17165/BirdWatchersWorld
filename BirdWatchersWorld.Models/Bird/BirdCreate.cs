using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Models
{
    public class BirdCreate
    {
        [Required, Display(Name = "Bird Name")]
        public string Name { get; set; }
        [Required, Display(Name = "Main Color")]
        public string MainColor { get; set; }
        [Required, Display(Name = "Secondary Color")]
        public string SecondColor { get; set; }

        [Display(Name = "Bird")]
        public int?[] Sighting { get; set; }
    }
}
