using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022A6PGBNGUYEN.Models
{
    public class ArtistWithMediaInfoViewModels : ArtistWithDetailViewModels
    {
        public ArtistWithMediaInfoViewModels()
        {
            MediaItems = new List<MediaItemBaseViewModels>();
        }


        public IEnumerable<MediaItemBaseViewModels> MediaItems { get; set; }
    }
}