using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MovieShop.Core.Models.Response
{
    public class ReviewResponseModel
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public decimal Rating { get; set; }

        [MinLength(5)]
        [MaxLength(1024)]
        public string ReviewText { get; set; }
    }
}
