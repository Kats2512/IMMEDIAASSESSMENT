using Newtonsoft.Json;
using Presentation.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (Request.IsAjaxRequest())
                return PartialView();
            else
                return View();
        }

        public ActionResult GetVenueListByVenueName(string venueName)
        {
            try
            {
                using (var client = new WebClient())
                {
                    string getLinks;
                    //Api URL with flickr.photos.search method
                    string baseUri = string.Format("https://localhost:44346/api/foursquare/getvenuerecommendations/{0}", venueName);
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
                    var data = JsonConvert.DeserializeObject<List<VenueListDataDto>>(getLinks);
                    return PartialView("_VenueList", data);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { errorCode = ex.Message });
            }
        }

        public ActionResult GetImagesForVenue(string venueId, string venueName)
        {
            try
            {
                using (var client = new WebClient())
                {
                    string getLinks;
                    //Api URL with flickr.photos.search method
                    string baseUri = string.Format("https://localhost:44346/api/foursquare/GetPhotosByVenueId/{0}", venueId);
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
                    var data = JsonConvert.DeserializeObject<List<PhotoDetailsDto>>(getLinks);
                    ViewBag.LocationName = venueName;
                    return PartialView("_VenuePhotos", data);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { errorCode = ex.Message });
            }

        }

        public ActionResult GetPhotoDetails(string photoId)
        {
            try
            {
                using (var client = new WebClient())
                {
                    string getLinks;
                    //Api URL with flickr.photos.search method
                    string baseUri = string.Format("https://localhost:44346/api/foursquare/getphotodetailsbyphotoid/{0}", photoId);
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
                    var data = JsonConvert.DeserializeObject<PhotoDetailsDto>(getLinks);
                    return PartialView("_PhotoDetails", data);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index", "Error", new { errorCode = ex.Message });
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return PartialView();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return PartialView();
        }
    }
}