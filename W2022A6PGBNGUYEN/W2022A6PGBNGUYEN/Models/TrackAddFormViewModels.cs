using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6PGBNGUYEN.Models
{
    public class TrackAddFormViewModels : TrackAddViewModels
    {
        [Required, Display(Name = "Track audio"), DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
    }
}