using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022A6PGBNGUYEN.Models
{
    public class MediaContentViewModels
    {
        public int Id { get; set; }

        public byte[] Content { get; set; }

        public string ContentType { get; set; }

    }
}