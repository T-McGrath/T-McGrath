using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection.Metadata.Ecma335;

namespace Locations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "|  1002 | Bernice                   |";
            Console.WriteLine(str.Length);
            CreateHostBuilder(args).Build().Run();
        }



        // This method is for Capstone 2. Cut and paste it when possible.
        //public string EndOfLine(string str)
        //{
        //    string result = str;
            

        //}
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
