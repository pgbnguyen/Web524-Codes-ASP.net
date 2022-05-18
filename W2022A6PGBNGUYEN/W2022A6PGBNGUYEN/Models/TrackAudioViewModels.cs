using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace W2022A6PGBNGUYEN.Models
{
    public class TrackAudioViewModels
    {
        public int Id { get; set; }

        public byte[] Audio { get; set; }

        public string AudioContentType { get; set; }
    }
}