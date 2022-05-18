using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using W2022A3PGBNGUYEN.EntityModels;

namespace W2022A3PGBNGUYEN.Models
{
    public class PlaylistBaseViewModel
    {
       


        public int PlaylistId { get; set; }

        [StringLength(120)]
        [Display(Name = "Playlist Name")]
        public string Name { get; set; }
        [Display(Name ="Playlist Track Count")]
        public int TracksCount { get; set; }
      

    }
}