using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO._4SquareResponseDto
{
    public class PhotoDetailsMetaDataDto
    {
        public int code { get; set; }
        public string requestId { get; set; }
    }

    public class PhotoDetailsSource
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PhotoDetailsPhoto2
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class PhotoDetailsUser
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public PhotoDetailsPhoto2 photo { get; set; }
    }

    public class PhotoDetailsContact
    {
    }

    public class PhotoDetailsLocation
    {
        public string address { get; set; }
        public string crossStreet { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public List<string> formattedAddress { get; set; }
    }

    public class PhotoDetailsIcon
    {
        public string prefix { get; set; }
        public string suffix { get; set; }
    }

    public class PhotoDetailsCategory
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public PhotoDetailsIcon icon { get; set; }
        public bool primary { get; set; }
    }

    public class PhotoDetailsVenue
    {
        public string id { get; set; }
        public string name { get; set; }
        public PhotoDetailsContact contact { get; set; }
        public PhotoDetailsLocation location { get; set; }
        public List<PhotoDetailsCategory> categories { get; set; }
    }

    public class PhotoDetailsPhoto
    {
        public string id { get; set; }
        public int createdAt { get; set; }
        public PhotoDetailsSource source { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public PhotoDetailsUser user { get; set; }
        public string visibility { get; set; }
        public PhotoDetailsVenue venue { get; set; }
    }

    public class PhotoDetailsResponse
    {
        public PhotoDetailsPhoto photo { get; set; }
    }

    public class PhotoDetailsRoot
    {
        public PhotoDetailsMetaDataDto meta { get; set; }
        public PhotoDetailsResponse response { get; set; }
    }
}
