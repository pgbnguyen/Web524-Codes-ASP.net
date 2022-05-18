using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A3PGBNGUYEN.Models
{
    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        [Display(Name="Artist name")]
        public string AlbumArtistName { get; set; }

        [Display(Name = "Album title")]
        public string AlbumTitle { get; set; }

        [Display(Name = "Media type")]
        public MediaTypeBaseViewModel MediaType { get; set; }
    }
}