using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using W2022A5PGBNGUYEN.EntityModels;

namespace W2022A5PGBNGUYEN.Models
{
    public class ArtistAddViewModels
    {
        public ArtistAddViewModels()
        {
            BirthOrStartDate = DateTime.Now;
            Albums = new List<Album>();
        }

        [Display(Name = "If applicable, Artist Birth Name")]
        public string BirthName { get; set; } //only used for a person who uses a stage name

        [Display(Name = "Birth date, or start date"), Required, DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthOrStartDate { get; set; } //birth date, for others it is the date that the artist started working in the music business.

        public string Executive { get; set; } //holds the username (e.g. amanda@example.com)

        public string Genre { get; set; } //This is used for when user create a new artist object, the available genres will be shown in an item-selection element.

        [Required, StringLength(50)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; } //artist's name or stage/performer name

        [Required, Display(Name = "Artist Photo URL")]
        public string UrlArtist { get; set; } //holds URL to photo of the artist

        [Display(Name = "Artist's primary genre")]
        public SelectList ArtistGenreList { get; set; }

        public IEnumerable<Album> Albums { get; set; }


    } 
}