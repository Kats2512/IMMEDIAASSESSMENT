using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO._4SquareResponseDto
{
    public class VenueRecommendationsMetaDataDto
    {
        public int code { get; set; }
        public string requestId { get; set; }
    }

    public class VenueRecommendationsFilter
    {
        public string name { get; set; }
        public string key { get; set; }
    }

    public class VenueRecommendationsSuggestedFilters
    {
        public string header { get; set; }
        public List<VenueRecommendationsFilter> filters { get; set; }
    }

    public class VenueRecommendationsCenter
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class VenueRecommendationsNe
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class VenueRecommendationsSw
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class VenueRecommendationsBounds
    {
        public VenueRecommendationsNe ne { get; set; }
        public VenueRecommendationsSw sw { get; set; }
    }

    public class VenueRecommendationsGeometry
    {
        public VenueRecommendationsBounds bounds { get; set; }
    }

    public class VenueRecommendationsGeocode
    {
        public string what { get; set; }
        public string where { get; set; }
        public VenueRecommendationsCenter center { get; set; }
        public string displayString { get; set; }
        public string cc { get; set; }
        public VenueRecommendationsGeometry geometry { get; set; }
        public string slug { get; set; }
        public string longId { get; set; }
    }

    public class VenueRecommendationsNe2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class VenueRecommendationsSw2
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class VenueRecommendationsSuggestedBounds
    {
        public VenueRecommendationsNe2 ne { get; set; }
        public VenueRecommendationsSw2 sw { get; set; }
    }

    public class VenueRecommendationsItem2
    {
        public string summary { get; set; }
        public string type { get; set; }
        public string reasonName { get; set; }
    }

    public class VenueRecommendationsReasons
    {
        public int count { get; set; }
        public List<VenueRecommendationsItem2> items { get; set; }
    }

    public class VenueRecommendationsLabeledLatLng
    {
        public string label { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
    }

    public class VenueRecommendationsLocation
    {
        public string address { get; set; }
        public string crossStreet { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public List<VenueRecommendationsLabeledLatLng> labeledLatLngs { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public List<string> formattedAddress { get; set; }
        public string neighborhood { get; set; }
    }

    public class VenueRecommendationsIcon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class VenueRecommendationsCategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public VenueRecommendationsIcon icon { get; set; }
        public bool primary { get; set; }
    }

    public class VenueRecommendationsPhotos
    {
        public int count { get; set; }
        public List<object> groups { get; set; }
    }

    public class VenueRecommendationsVenuePage
    {
        public string id { get; set; }
    }

    public class VenueRecommendationsVenue
    {
        public string id { get; set; }
        public string name { get; set; }
        public VenueRecommendationsLocation location { get; set; }
        public List<VenueRecommendationsCategory> categories { get; set; }
        public VenueRecommendationsPhotos photos { get; set; }
        public VenueRecommendationsVenuePage venuePage { get; set; }
    }

    public class VenueRecommendationsItem
    {
        public VenueRecommendationsReasons reasons { get; set; }
        public VenueRecommendationsVenue venue { get; set; }
        public string referralId { get; set; }
    }

    public class VenueRecommendationsGroup
    {
        public string type { get; set; }
        public string name { get; set; }
        public List<VenueRecommendationsItem> items { get; set; }
    }

    public class VenueRecommendationsResponse
    {
        public VenueRecommendationsSuggestedFilters suggestedFilters { get; set; }
        public VenueRecommendationsGeocode geocode { get; set; }
        public string headerLocation { get; set; }
        public string headerFullLocation { get; set; }
        public string headerLocationGranularity { get; set; }
        public int totalResults { get; set; }
        public VenueRecommendationsSuggestedBounds suggestedBounds { get; set; }
        public List<VenueRecommendationsGroup> groups { get; set; }
    }

    public class VenueRecommendationsRoot
    {
        public VenueRecommendationsMetaDataDto meta { get; set; }
        public VenueRecommendationsResponse response { get; set; }
    }
}
