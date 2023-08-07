using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models.DBEntities
{
    public class Sector


    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SectorID { get; set; }

        public string SectorName { get; set; }

        public Boolean SectorIsActive { get; set;}
    }
}
