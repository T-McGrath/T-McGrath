namespace CampgroundReservations.Models
{
    public class Campground
    {
        public int CampgroundId { get; set; }
        public int ParkId { get; set; }
        public string Name { get; set; }
        public int OpenFromMonth { get; set; }
        public int OpenToMonth { get; set; }
        public double DailyFee { get; set; }

        public Campground()
        {

        }
        
        public Campground(int campgroundId, int parkId, string name, int openFromMonth, int openToMonth, double dailyFee)
        {
            CampgroundId = campgroundId;
            ParkId = parkId;
            Name = name;
            OpenFromMonth = openFromMonth;
            OpenToMonth = openToMonth;
            DailyFee = dailyFee;
        }
    }
}
