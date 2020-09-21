using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VenueDetailsBySearchDto
    {
        public Guid Id { get; set; }
        public string DisplayString { get; set; }
        public string HeaderLocation { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string VenueId { get; set; }
        public string VenueName { get; set; }
        public string VenueCC { get; set; }
        public string VenueCity { get; set; }
        public string VenueCountry { get; set; }
        public string VenueFormattedAddress { get; set; }
        public string CategoryName { get; set; }
        public string CategoryPrefix { get; set; }
        public string CategorySuffix { get; set; }
        public string CategoryId { get; set; }
    }
}
