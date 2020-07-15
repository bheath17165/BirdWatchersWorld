using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdWatchersWorld.Models.Spotting
{
    public class SpotterDetail
    {
        public string Id { get; set; }

        [Required, Display(Name = "First Name: ")]
        public string FirstName { get; set; }
        [Required, Display(Name = "Last Name: ")]
        public string LastName { get; set; }
        [Display(Name = "Full Name: ")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        [Display(Name = "User Name: ")]
        public string UserName { get; set; }
        [Display(Name = "Birds Seen: ")]
        public List<BirdListItem> BirdsSeen { get; set; }
    }
}
