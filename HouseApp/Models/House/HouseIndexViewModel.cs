using System.Drawing;

namespace HouseApp.Models.House
{
    public class HouseIndexViewModel
    {
        public Guid? Id { get; set; }
        public int BathroomCount { get; set; }
        public int BedroomCount { get; set; }
        public bool IsForRentOrSale { get; set; }
        public int Price { get; set; }
        public int BuildingAge { get; set; }

    }
}
