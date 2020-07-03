using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Models
{
    public class BirdEdit
    {
        public int BirdID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Main Color")]
        public string MainColor { get; set; }
        [Display(Name = "Secondary Color")]
        public string SecondColor { get; set; }
    }
}
