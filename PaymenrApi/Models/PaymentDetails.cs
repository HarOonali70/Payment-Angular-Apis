using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymenrApi.Models
{
    public class PaymentDetails
    {
        [Key]
        public int PaymentDetailId { get; set; }
        [Column(TypeName ="nvarchar(100)")]
        public string CradOwnerName { get; set; }
        [Column(TypeName = "nvarchar(16)")]
        public string CradNumber { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public string ExpirationDate { get; set; }
        [Column(TypeName = "nvarchar(3)")]
        public string SecurityCode { get; set; }
    }
}
