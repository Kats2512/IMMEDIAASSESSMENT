using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Presentation.DTO
{
    public class PhotoDetailsDto
    {
        public Guid Id { get; set; }
        public string HeaderLocation { get; set; }
        public string CategoryName { get; set; }
        public string VenueFormattedAddress { get; set; }
        public DateTime DateCreated { get; set; }
        public string PhotoId { get; set; }
        public string PhotoPrefix { get; set; }
        public string PhotoSuffix { get; set; }
        public string PhotoWidth { get; set; }
        public string PhotoHeight { get; set; }
        public string PhotoOwner { get; set; }
        public string PhotoVisibility { get; set; }
        public string VenueId { get; set; }
    }
}