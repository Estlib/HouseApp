using System.Drawing;

namespace HouseApp.Models.House
{
    public class HouseCreateUpdateViewModel
    {
        public Guid? Id { get; set; }
        public double SquareMeters { get; set; }
        public string HouseColours { get; set; }
        public string RoofType { get; set; }
        public int TotalRoomCount { get; set; }
        public int BathroomCount { get; set; }
        public int BedroomCount { get; set; }
        public bool IsForRentOrSale { get; set; }
        public int Price { get; set; }
        public int BuildingAge { get; set; }
        public DateTime BuiltAt { get; set; }
        public int FloorCount { get; set; }
        public string FullAddress { get; set; }

        //DB variables
        public DateTime EntryCreatedAt { get; set; }
        public DateTime EntryUpdatedAt { get; set; }
    }
}
