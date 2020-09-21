using DTO;
using DTO._4SquareResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interface
{
    public interface IFourSquareService
    {
        Task<int> SaveVenueRecommendations(VenueRecommendationsRoot data, string searchLocation);
        Task<int> SaveVenuePhotos(VenuePhotosRoot data, string venueId);
        Task<List<VenueDetailsBySearchDto>> ListVenuesByVenueAreaName(string areaName);
        Task<List<VenuePhotosDto>> GetVenuePhotos(string venueId);
        Task<PhotoDetailsDto> GetPhotoDetailsByPhotoId(string photoId);
    }
}
