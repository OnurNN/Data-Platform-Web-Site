using System.ComponentModel;

namespace Proje.Models
{
    public class SectorViewModel
    {
        [DisplayName("ID")]
        public int SectorID { get; set; }

        [DisplayName("Sector Name")]
        public string SectorName { get; set; }



        [DisplayName("Is Active")]
        public Boolean SectorIsActive { get; set; }
    }
}
