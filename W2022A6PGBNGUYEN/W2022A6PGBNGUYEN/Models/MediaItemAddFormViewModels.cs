using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace W2022A6PGBNGUYEN.Models
{
    public class MediaItemAddFormViewModels : MediaItemAddViewModels
    {

        [Required, Display(Name = "Media upload"), DataType(DataType.Upload)]
        public string MediaUpload { get; set; }
    }
}