using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Request
{
    public class PurchaseRequestModel
    {
            public PurchaseRequestModel()
            {
                PurchaseDateTime = DateTime.Now;
                PurchaseNumber = Guid.NewGuid();
            }

            public int UserId { get; set; }
            public Guid? PurchaseNumber { get; set; }
            public decimal? TotalPrice { get; set; }
            public DateTime? PurchaseDateTime { get; set; }
            public int MovieId { get; set; }
        
    }
}
