using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using W2022A5PGBNGUYEN.EntityModels;

namespace W2022A5PGBNGUYEN.Models
{
    public class TrackWithDetailViewModels : TrackBaseViewModels
    {
        public TrackWithDetailViewModels()
        {
            Albums = new List<Album>();
            AlbumNames = new List<string>();
        }

        [Display(Name = "Albums with this track")]
        public IEnumerable<string> AlbumNames { get; set; }

        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        public IEnumerable<Album> Albums { get; set; }
    }
}