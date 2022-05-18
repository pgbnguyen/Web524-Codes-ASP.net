using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A3PGBNGUYEN.Models
{
    public class TrackBaseViewModel
    {

        [Key]
        [Display(Name = "Track ID")]
        public int TrackId { get; set; }

        [Required(ErrorMessage = "Empty Track Name is not valid")]
        [StringLength(200)]
        [Display(Name = "Track Name")]
        public string Name { get; set; }

        [StringLength(220, ErrorMessage = "Please choose the valid composer name")]
        [Display(Name = "Composer")]
        [Required(ErrorMessage = "Track must have composer")]
        public string Composer { get; set; }
        [Display(Name = "Length (ms)")]
        [Range(1, float.MaxValue, ErrorMessage = "Please choose the valid time")]
        public int Milliseconds { get; set; }

        [Display(Name = "Price")]
        [Range(1, float.MaxValue, ErrorMessage = "Please choose the valid price")]
        public decimal UnitPrice { get; set; }
        public string NameFull
        {
            get
            {
                var ms = Math.Round((((double)Milliseconds / 1000) / 60), 1);
                var composer = string.IsNullOrEmpty(Composer) ? "" : ", composer " + Composer;
                var trackLength = (ms > 0) ? ", " + ms.ToString() + " minutes" : "";
                var unitPrice = (UnitPrice > 0) ? ", $ " + UnitPrice.ToString() : "";
                return string.Format("{0}{1}{2}{3}", Name, composer, trackLength, unitPrice);
            }
        }
        // Composed read-only property to display short name.
        public string NameShort
        {
            get
            {
                var ms = Math.Round((((double)Milliseconds / 1000) / 60), 1);
                var trackLength = (ms > 0) ? ms.ToString() + " minutes" : "";
                var unitPrice = (UnitPrice > 0) ? " $ " + UnitPrice.ToString() : "";
                return string.Format("{0} - {1} - {2}", Name, trackLength, unitPrice);
            }
        }

    }
}