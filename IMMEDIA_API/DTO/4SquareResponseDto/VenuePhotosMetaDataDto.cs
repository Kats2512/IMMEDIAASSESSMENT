using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO._4SquareResponseDto
{
    public class VenuePhotosMetaDataDto
    {
        public int code { get; set; }
        public string requestId { get; set; }
    }

    public class VenuePhotosSource
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class VenuePhotosPhoto
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class VenuePhotosUser
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public VenuePhotosPhoto photo { get; set; }
    }

    public class VenuePhotosCheckin
    {
        public string id { get; set; }
        public int createdAt { get; set; }
        public string type { get; set; }
        public int timeZoneOffset { get; set; }
    }

    public class VenuePhotosItem
    {
        public string id { get; set; }
        public int createdAt { get; set; }
        public VenuePhotosSource source { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public VenuePhotosUser user { get; set; }
        public VenuePhotosCheckin checkin { get; set; }
        public string visibility { get; set; }
    }

    public class VenuePhotosPhotos
    {
        public int count { get; set; }
        public List<VenuePhotosItem> items { get; set; }
        public int dupesRemoved { get; set; }
    }

    public class VenuePhotosResponse
    {
        public VenuePhotosPhotos photos { get; set; }
    }
    public class VenuePhotosRoot
    {
        public VenuePhotosMetaDataDto meta { get; set; }
        public VenuePhotosResponse response { get; set; }
    }
}
