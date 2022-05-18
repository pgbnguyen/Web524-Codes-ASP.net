using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A5PGBNGUYEN.EntityModels
{
    public class Track
    {
    
        public Track()
        {
            Albums = new List<Album>();
        }

        public int TrackId { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; }

        // Simple comma-separated string of all the track's composers
        [Required, StringLength(500)]
        public string Composers { get; set; }

        [Required]
        public string Genre { get; set; }

        // User name who added/edited the track
        
        public string Clerk { get; set; }

        public ICollection<Album> Albums { get; set; }

        //public byte[] Audio { get; set; }
        //public string AudioContentType { get; set; }
    }
    
}