using System;
using System.Collections.Generic;
using System.Text;

namespace MovieShop.Core.Entities
{
    // One movei can have multiple trailers
    public class Trailer
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string TrailerUrl { get; set; }
        public string Name { get; set; }

        // Navigation properties
        public Movie Movie { get; set; }
    }
}
