using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace HotelReservations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"V2 cam: {calcDiag(103, 135)}");
            Console.WriteLine($"Pro cam: {calcDiag(150, 150)}");
            //CreateHostBuilder(args).Build().Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        public static double calcDiag(int length, int width)
        {
            return Math.Sqrt(length * length + width * width);
        }
    }
}