using System.Collections.Generic;
using TourApi.Models;

namespace TourApi.DTOs
{
    public class TourDTO
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string Description { get; set; }
        public int TypesOfTourismId { get; set; }
        public TypesOfTourism TypesOfTourism { get; set; }
        public List<TourPrice> TourPriceList { get; set; }
        public List<TourDetails> TourDetailsList { get; set; }
        public List<TouristGroup> TouristGroup { get; set; }
    }
}