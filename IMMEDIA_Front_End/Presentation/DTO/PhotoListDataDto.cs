using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.DTO
{
    public class PhotoListDataDto
    {
        public Guid PhotoId { get; set; }
        public string PhotoSuffix { get; set; }
        public string PhotoHeight { get; set; }
        public string PhotoPrefix { get; set; }
        public string PhotoWidth { get; set; }
    }
}