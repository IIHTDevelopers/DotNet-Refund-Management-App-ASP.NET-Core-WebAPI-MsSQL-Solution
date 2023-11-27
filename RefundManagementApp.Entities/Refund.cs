using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System;

namespace RefundManagementApp.Entities
{
    public class Refund
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RefundId { get; set; }
        public string Reason { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Approved { get; set; }
    }
}
