using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Models.Spotting
{
    public class SpotterEdit
    {
        public int SpotterID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
    }
}
