using System.ComponentModel;

namespace Proje.Models
{
    public class PersonalViewModel
    {

        [DisplayName("Personal ID")]
        public int PersonalId { get; set; }

        [DisplayName("Name")]
        public string NameSurname { get; set; }

        [DisplayName("Gender")]
        public string Gender { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
