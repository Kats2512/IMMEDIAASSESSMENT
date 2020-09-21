using Data;
using Data.Implementation;
using Data.Interface;
using DTO;
using DTO._4SquareResponseDto;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{

    //Note: Could have used Automapper instead of typing this long pieces of savig code to the database but I opted to just out of personal preference.
    public class FourSquareService : IFourSquareService
    {
        //Interface declarations that will be called in the class
        private IGenericRepository<FourSquareVenueRecommendationsMetaData> _fourSquareVenueListRepository = null;

        private IGenericRepository<FourSquarePhotoMetaData> _fourSquarePhotoRepository = null;

        //Constructor, initialize interfaces
        public FourSquareService()
        {
            this._fourSquareVenueListRepository = new GenericRepository<FourSquareVenueRecommendationsMetaData>();
            this._fourSquarePhotoRepository = new GenericRepository<FourSquarePhotoMetaData>();
        }

        //Save list of venue recommendations the user has searched to the database
        public async Task<int> SaveVenueRecommendations(VenueRecommendationsRoot data, string searchLocation)
        {
            try
            {
                var result = 0;

                var items = await _fourSquareVenueListRepository.GetAll();

                foreach (var group in data.response.groups)
                {
                    foreach (var item in group.items)
                    {
                        //Check DB if the venue searched already exists
                        //If the venue does exist then check each venueId to see if it exists or not
                        //If the venueId already exists then do not proceed with a save, avoid duplicate enteries
                        if (!items.Where(x => x.VenueId == item.venue.id).Any())
                        {
                            var formattedAddress = "";
                            var dbVenue = new FourSquareVenueRecommendationsMetaData();
                            dbVenue.Id = Guid.NewGuid();
                            dbVenue.HeaderLocation = data.response.headerLocation;
                            dbVenue.HeaderLocationFull = data.response.headerLocation;
                            dbVenue.HeaderLocationGranularity = data.response.headerLocationGranularity;
                            dbVenue.DisplayString = data.response.geocode.displayString;
                            dbVenue.Longitude = item.venue.location.lng.ToString();//data.response.geocode.center.lng.ToString();
                            dbVenue.Latitude = item.venue.location.lat.ToString();//data.response.geocode.center.lat.ToString();
                            dbVenue.VenueId = item.venue.id;
                            dbVenue.VenueName = item.venue.name;
                            dbVenue.VenuePostalCode = item.venue.location.postalCode;
                            dbVenue.VenueCC = item.venue.location.cc;
                            dbVenue.VenueCity = item.venue.location.city;
                            dbVenue.VenueState = item.venue.location.state;
                            dbVenue.VenueCountry = item.venue.location.country;
                            var lastItem = item.venue.location.formattedAddress.Last();
                            foreach (var addressItem in item.venue.location.formattedAddress)
                            {
                                if (addressItem.Equals(lastItem))
                                    formattedAddress += addressItem;
                                else
                                    formattedAddress += addressItem + ", ";
                            }
                            dbVenue.VenueFormattedAddress = formattedAddress;
                            foreach (var category in item.venue.categories)
                            {
                                dbVenue.CategoryId = category.id;
                                dbVenue.CategoryName = category.name;
                                dbVenue.CategoryPluralName = category.pluralName;
                                dbVenue.CategoryShortName = category.shortName;
                                dbVenue.CategoryPrefix = category.icon.prefix;
                                dbVenue.CategorySuffix = category.icon.suffix;
                            }
                            dbVenue.DateCreated = DateTime.Now;
                            dbVenue.UserSearchString = searchLocation;
                            _fourSquareVenueListRepository.Insert(dbVenue);
                            result += await _fourSquareVenueListRepository.Save();
                        }

                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> SaveVenuePhotos(VenuePhotosRoot data, string venueId)
        {
            try
            {
                var result = 0;
                //Check DB if the photo exists
                //If the venue does exist then check each venueId to see if it exists or not
                //If the photoId already exists then do not proceed with a save, avoid duplicate enteries
                var items = await _fourSquarePhotoRepository.GetAll();
                foreach (var item in data.response.photos.items)
                {
                    if (!items.Where(x => x.PhotoId == item.id).Any())
                    {
                        var dbPhoto = new FourSquarePhotoMetaData();
                        dbPhoto.Id = Guid.NewGuid();
                        dbPhoto.DateCreated = DateTime.Now;
                        dbPhoto.PhotoId = item.id;
                        dbPhoto.PhotoPrefix = item.prefix;
                        dbPhoto.PhotoSuffix = item.suffix;
                        dbPhoto.PhotoWidth = item.width.ToString();
                        dbPhoto.PhotoHeight = item.height.ToString();
                        dbPhoto.PhotoOwner = item.user.firstName + " " + item.user.lastName;
                        dbPhoto.PhotoVisibility = item.visibility;
                        dbPhoto.VenueId = venueId;
                        _fourSquarePhotoRepository.Insert(dbPhoto);
                        result += await _fourSquarePhotoRepository.Save();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region SQLProcCalls
        //Call procs from SQL and return them into an object
        public async Task<List<VenueDetailsBySearchDto>> ListVenuesByVenueAreaName(string areaName)
        {
            List<VenueDetailsBySearchDto> venueList = new List<VenueDetailsBySearchDto>();
            var result = await _fourSquarePhotoRepository.ExecuteCustomStoredProc<VenueDetailsBySearchDto>("exec Foursquare_VenueDetails_ListVenuesByVenueAreaName @AreaName", new SqlParameter("AreaName", areaName));
            return venueList = result.ToList();
        }

        public async Task<List<VenuePhotosDto>> GetVenuePhotos(string venueId)
        {
            try
            {
                List<VenuePhotosDto> photoList = new List<VenuePhotosDto>();
                var result = await _fourSquarePhotoRepository.ExecuteCustomStoredProc<VenuePhotosDto>("exec Foursquare_PhotoList_PhotoListByVenueId @VenueId", new SqlParameter("VenueId", venueId));
                return photoList = result.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<PhotoDetailsDto> GetPhotoDetailsByPhotoId(string photoId)
        {
            try
            {
                PhotoDetailsDto photoList = new PhotoDetailsDto();
                var result = await _fourSquarePhotoRepository.ExecuteCustomStoredProcSingleItem<PhotoDetailsDto>("exec Foursquare_PhotoDetails_GetPhotoDetailsByPhotoId @PhotoId", new SqlParameter("PhotoId", photoId));
                return photoList = result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
