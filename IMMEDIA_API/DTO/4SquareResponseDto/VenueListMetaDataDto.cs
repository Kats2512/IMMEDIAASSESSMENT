using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO._4SquareResponseDto
{
    //DTO for the response from the 4Square Venue API Call
    public class VenueListMetaDataDto
    {
        public int code { get; set; }
        public string requestId { get; set; }
    }
    public class VenueListMetaDataLabeledLatLng
    {
        public string label { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class VenueListMetaDataLocation
    {
        public string address { get; set; }
        public string crossStreet { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public List<VenueListMetaDataLabeledLatLng> labeledLatLngs { get; set; }
        public int distance { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public List<string> formattedAddress { get; set; }
    }

    public class VenueListMetaDataIcon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class VenueListMetaDataCategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public VenueListMetaDataIcon icon { get; set; }
        public bool primary { get; set; }
    }

    public class VenueListMetaDataVenuePage
    {
        public string id { get; set; }
    }

    public class VenueListMetaDataVenue
    {
        public string id { get; set; }
        public string name { get; set; }
        public VenueListMetaDataLocation location { get; set; }
        public List<VenueListMetaDataCategory> categories { get; set; }
        public VenueListMetaDataVenuePage venuePage { get; set; }
    }

    public class VenueListMetaDataResponse
    {
        public List<VenueListMetaDataVenue> venues { get; set; }
    }

    public class VenueListMetaDataVenuesRoot
    {
        public VenueListMetaDataDto meta { get; set; }
        public VenueListMetaDataResponse response { get; set; }
    }
}
