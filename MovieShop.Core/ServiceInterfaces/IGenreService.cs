using MovieShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.ServiceInterfaces
{
   public interface IGenreService
    {
        IEnumerable<Genre> GetAllGenres();
    }
}
