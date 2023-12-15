using System;

namespace HotelReservationsClient
{
    class Program
    {
        private const string ApiUrl = "https://localhost:44322/";
        static void Main()
        {
            Console.WriteLine($"V2 cam: {calcDiag(103, 135)}");
            Console.WriteLine($"Pro cam: {calcDiag(150, 150)}");

            //HotelApp app = new HotelApp(ApiUrl);
            //app.Run();
        }

        public static double calcDiag(int length, int width)
        {
            return Math.Sqrt(length * length + width * width);
        }
    }
}
