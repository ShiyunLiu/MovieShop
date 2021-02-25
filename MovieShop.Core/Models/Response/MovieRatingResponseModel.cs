﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Models.Response
{
    public class MovieRatingResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public decimal Rating { get; set; }
    }
}
