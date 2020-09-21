using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VenuePhotosDto
    {
        public Guid Id { get; set; }
        public string PhotoId { get; set; }
        public string PhotoSuffix { get; set; }
        public string PhotoHeight { get; set; }
        public string PhotoPrefix { get; set; }
        public string PhotoWidth { get; set; }
    }
}
