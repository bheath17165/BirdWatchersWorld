using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Models
{
    public class BirdDetail
    {
        [Display(Name = "Bird ID: ")]
        public int BirdID { get; set; }
        [Display(Name = "Bird Name: ")]
        public string Name { get; set; }
        [Display(Name = "Main Color: ")]
        public string MainColor { get; set; }
        [Display(Name = "Secondary Color: ")]
        public string SecondColor { get; set; }
        [Display(Name = "Spotted By:")]
        public string SpotterName { get; set; }
        [Display(Name = "Time Seen: ")]
        public DateTimeOffset TimeSeen { get; set; }
    }
}
