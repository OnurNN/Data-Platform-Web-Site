using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proje.Models.DBEntities
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyStatus { get; set; }
        public int SectorID { get; set; }
        public int EntegrationID { get; set; }
        public DateTime Contract_Start {get; set; }
        public DateTime Contract_End { get; set; }
        public string Authorized { get; set;}

    }

    

}