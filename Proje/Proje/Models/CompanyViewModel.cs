using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Proje.Models
{

    public class CompanyViewModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        
        [DisplayName("Company Status")]
        public string CompanyStatus { get; set; }
        [DisplayName("Sector")]
        public int SectorID { get; set; }
        [DisplayName("Integrator")]
        public int EntegrationID { get; set; }
        [DisplayName("Contract Start")]
        public DateTime Contract_Start { get; set; }
        [DisplayName("Contract End")]
        public DateTime Contract_End { get; set; }
        [DisplayName("Authorized")]
        public string Authorized { get; set; }
        


    }
}
