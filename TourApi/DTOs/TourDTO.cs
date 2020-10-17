using System.Collections.Generic;
using TourApi.Models;

namespace TourApi.DTOs
{
    public class TourDTO
    {
        public int TourId { get; set; }
        public string TourName { get; set; }
        public string TourCharacteristics { get; set; }
        public int TypeId { get; set; }
        public int TourPriceId { get; set; }
        public TypesOfTourism TypesOfTourism { get; set; }
        public TourPrice TourPrice { get; set; }
        public List<TourDetailsOfStaff> TourDetailsOfStaffList { get; set; }
        public List<TourDetailsOfCustomer> TourDetailsOfCustomerList { get; set; }
        public List<TourDetails> TourDetailsList { get; set; }
        public List<TouristGroup> TouristGroup { get; set; }
    }
}