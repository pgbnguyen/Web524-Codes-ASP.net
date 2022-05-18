using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A5PGBNGUYEN.Models
{
    public class AlbumBaseViewModels
    {
        [Required]
        public int AlbumId { get; set; }

        [Display(Name = "Coordinaor Who Looks after the album")]
        public string Coordinator { get; set; } //  holds the username (e.g. amanda@example.com) of the authenticated user who is in the process of adding a new Album object

        [StringLength(30)]
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; } // holds a genre string/value. creating a new Album object, the available genres will be shown in an item-selection element

        [StringLength(40)]
        [Display(Name = "Album Name")]
        public string Name { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Album cover art")]
        public string UrlAlbum { get; set; } //hold the a URL to an image of the album
    }
}