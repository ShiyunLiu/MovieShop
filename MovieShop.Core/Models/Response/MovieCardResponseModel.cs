using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Response
{
   public class MovieCardResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal? Revenue { get; set; }
        public string PosterUrl { get; set; }
    }
}
