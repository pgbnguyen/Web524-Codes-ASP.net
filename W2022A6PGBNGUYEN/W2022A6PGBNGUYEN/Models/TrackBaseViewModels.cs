using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using W2022A6PGBNGUYEN.EntityModels;

namespace W2022A6PGBNGUYEN.Models
{
    public class TrackBaseViewModels 
    {
        public TrackBaseViewModels()
        {
            Albums = new List<Album>();
        }

        [Required]
        public int Id { get; set; }

        [StringLength(40)]
        [Display(Name = "Clerk who helps with album tasks")]
        public string Clerk { get; set; } // holds the username (e.g. amanda@example.com) of the authenticated user who is in the process of adding a new Track object

        [Display(Name = "Composer name (comma-separated)")]
        public string Composers { get; set; } //holds the names of the track's composers. user will simply type comma separators between the names of multiple composers so no hard-coding is required.

        [StringLength(30)]
        [Display(Name = "Track genre")]
        public string Genre { get; set; } //holds a genre string/value

        [Required, StringLength(60), Display(Name = "Track name")]
        public string Name { get; set; }
        public IEnumerable<Album> Albums { get; set; }

    }
}