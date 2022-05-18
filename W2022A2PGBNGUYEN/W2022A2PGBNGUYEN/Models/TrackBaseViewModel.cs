using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using W2022A2PGBNGUYEN.EntityModels;

namespace W2022A2PGBNGUYEN.Models
{
    public class TrackBaseViewModel
    {

        [Key]
        [Display(Name = "Track ID")]
        public int TrackId { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        public int? AlbumId { get; set; }

        public int MediaTypeId { get; set; }

        public int? GenreId { get; set; }

        [StringLength(220)]
        [Display(Name ="Composer Name")]
        public string Composer { get; set; }
        [Display(Name ="Track Length (Milliseconds)")]
        public int Milliseconds { get; set; }

        public int? Bytes { get; set; }

   
        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }
    }
}