using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foodies
{
    class ClassInvoiceDetails
    {
        public int InvoiceID { get; set; }
        public int CustID { get; set; }
        public int OrderID { get; set; }
        public string CustName { get; set; }
        public string ProductName { get; set; }
        public decimal ProductQuantity { get; set; }
        public decimal ProductRate { get; set; }
        public decimal ProductAmount { get; set; }
        public decimal ProductAmountWithGST { get; set; }
        public TimeSpan OrdertTime { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Totalqty { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountWithGST { get; set; }
        public decimal DiscountInPercent { get; set; }
    }
}