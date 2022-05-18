using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6PGBNGUYEN.Models
{
    public class ArtistBaseViewModels
    { //public Artist()
        //{
        //    Albums = new HashSet<Album>();
        //    BirthOrStartDate = DateTime.Now.AddYears(-15);
        //}


        //public int Id { get; set; }
        [Required]
        public int Id { get; set; }

        [StringLength(40), Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; } //only used for a person who uses a stage name

        [Display(Name = "Birth date, or start date"), Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; } //birth date, for others it is the date that the artist started working in the music business.

        [StringLength(40), Display(Name = "Executive who looks after this artist")]
        public string Executive { get; set; } //holds the username (e.g. amanda@example.com)

        [StringLength(40), Display(Name = "Artist's primary genre")]
        public string Genre { get; set; } //This is used for when user create a new artist object, the available genres will be shown in an item-selection element.

        [StringLength(40), Display(Name = "Artist name or stage name"), Required]
        public string Name { get; set; } //artist's name or stage/performer name

        [StringLength(50), Display(Name = "Artist Photo"), Required]
        public string UrlArtist { get; set; } //holds URL to photo of the artist

    }
}