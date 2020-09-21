using DTO;
using DTO._4SquareResponseDto;
using Newtonsoft.Json;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Presentation.Controllers
{
    //Route attribute
    [RoutePrefix("api/foursquare")]
    public class FourSquareController : ApiController
    {
        //Interface declarations that will be called in the class
        private IFourSquareService _fourSquareService;

        //Get 4Square Credentials From Web.Config
        private readonly string client_id = System.Configuration.ConfigurationManager.AppSettings["client_id"].ToString();
        private readonly string client_secret = System.Configuration.ConfigurationManager.AppSettings["client_secret"].ToString();

        //Constructor, initialize interfaces
        public FourSquareController(IFourSquareService fourSquareService)
        {
            this._fourSquareService = fourSquareService;
        }

        //Call 4Square api to get a list of venue recommendations
        //Use Async Task So The Application Can Continue With Other Work And Not Dependant On This Task Being Completed
        //Route Attribute With HTTPGET Method.
        [Route("getvenuerecommendations/{venuename}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetVenueRecommendations(string venueName)
        {
            using (var client = new WebClient())
            {
                string getLinks;
                //Api URL with flickr.photos.search method
                string baseUri = string.Format("https://api.foursquare.com/v2/venues/explore?near={0}&client_id={1}&client_secret={2}&v=20150917", venueName, client_id, client_secret);
                try
                {
                    //API call to get data
                    getLinks = client.DownloadString(baseUri);
                }
                catch (Exception ex)
                {
                    //Error Trapping
                    throw new Exception(ex.Message);
                }
                //Once there is data store it into the class in a list that is a JSON object
                var data = JsonConvert.DeserializeObject<VenueRecommendationsRoot>(getLinks);

                //Pass the data to the service worker to save the data to the database. Pass the response from the api and the venue the user searched for.
                var saveResult = await _fourSquareService.SaveVenueRecommendations(data, venueName);

                //Get a list of venues from the database. Washed up data, removed all unwanted data and only send back what I think it usefull for a front end display.
                var venueList = await _fourSquareService.ListVenuesByVenueAreaName(venueName);

                return Ok(venueList);
            }
        }

        //Call 4Square api to get a list of photos by a venue
        //Use Async Task So The Application Can Continue With Other Work And Not Dependant On This Task Being Completed
        //Route Attribute With HTTPGET Method.
        [Route("getphotosbyvenueid/{venueid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPhotosByVenueId(string venueId)
        {
            using (var client = new WebClient())
            {
                string getLinks;
                //Api URL with flickr.photos.search method
                string baseUri = string.Format("https://api.foursquare.com/v2/venues/{0}/photos?&client_id={1}&client_secret={2}&v=20150917", venueId, client_id, client_secret);
                try
                {
                    //API call to get data
                    getLinks = client.DownloadString(baseUri);
                }
                catch (Exception ex)
                {
                    //Error Trapping
                    throw new Exception(ex.Message);
                }
                //Once there is data store it into the class in a list that is a JSON object
                var data = JsonConvert.DeserializeObject<VenuePhotosRoot>(getLinks);

                //Pass the data to the service worker to save the data to the database. Pass the response from the api and the venue the user searched for.
                var saveResult = await _fourSquareService.SaveVenuePhotos(data, venueId);

                var venuePhotos = await _fourSquareService.GetVenuePhotos(venueId);

                return Ok(venuePhotos);
            }
        }

        //Call 4Square api to get photo details
        //Use Async Task So The Application Can Continue With Other Work And Not Dependant On This Task Being Completed
        //Route Attribute With HTTPGET Method.
        [Route("getphotodetails/{photoid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPhotoDetails(string photoId)
        {
            using (var client = new WebClient())
            {
                string getLinks = string.Empty;
                //Api URL with flickr.photos.search method
                string baseUri = string.Format("https://api.foursquare.com/v2/photos/{0}?&client_id={1}&client_secret={2}&v=20150917", photoId, client_id, client_secret);
                try
                {
                    await Task.Run(() =>
                        {
                            //API call to get data
                            getLinks = client.DownloadString(baseUri);
                        });
                }
                catch (Exception ex)
                {
                    //Error Trapping
                    throw new Exception(ex.Message);
                }
                //Once there is data store it into the class in a list that is a JSON object
                var data = JsonConvert.DeserializeObject<PhotoDetailsRoot>(getLinks);

                return Ok(data);
            }
        }

        //Get photo details from the database as it has already been saved in previous call when searching for a venue
        [Route("getphotodetailsbyphotoid/{photoid}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetPhotoDetailsByPhotoId(string photoId)
        {
            var data = await _fourSquareService.GetPhotoDetailsByPhotoId(photoId);
            return Ok(data);
        }
    }
}
