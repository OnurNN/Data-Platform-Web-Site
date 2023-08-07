using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models.DBEntities
{
    public class Personal


    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       
        public int PersonalId { get; set; }
        public string NameSurname { get; set; }
        public string Gender { get; set; }
        public string Title { get; set; }

        public string PhoneNumber { get; set; }
    }
}
