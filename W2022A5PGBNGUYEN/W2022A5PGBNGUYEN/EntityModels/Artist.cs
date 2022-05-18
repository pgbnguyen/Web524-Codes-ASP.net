using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A5PGBNGUYEN.EntityModels
{
    public class Artist
    {
        public Artist()
        {
            BirthName = "";
            BirthOrStartDate = DateTime.Now.AddYears(-20);
            Albums = new HashSet<Album>();


        }

        public int ArtistId { get; set; }

        // For an individual, can be birth name, or a stage/performer name
        // For a duo/band/group/orchestra, will typically be a stage/performer name
        
        public string Name { get; set; }

        // For an individual, a birth name
       
        public string BirthName { get; set; }

        // For an individual, a birth date
        // For all others, can be the date the artist started working together
        public DateTime BirthOrStartDate { get; set; }

        // Get from Apple iTunes Preview, Amazon, or Wikipedia
        
        public string UrlArtist { get; set; }

       
        public string Genre { get; set; }

        // User name who looks after this artist
       
        public string Executive { get; set; }
        [Required]
        public ICollection<Album> Albums { get; set; }


    }
    
}