using System;
using System.Collections.Generic;
using System.Text;

namespace RefundManagementApp.BusinessLayer.ViewModels
{
    public class RefundViewModel
    {
        public int RefundId { get; set; }
        public string Reason { get; set; }
        public decimal Amount { get; set; }
        public DateTime RequestDate { get; set; }
        public bool Approved { get; set; }
    }
}
