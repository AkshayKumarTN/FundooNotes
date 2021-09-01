// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Bridgelabz">
//   Copyright © 2021 Company="BridgeLabz"
// </copyright>
// <creator name="Akshay Kumar T N "/>
// ----------------------------------------------------------------------------------------------------------
namespace FundooNotes
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Hosting;

    /// <summary>
    /// Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        ///  Main Method
        /// </summary>
        /// <param name="args"> string[] args </param>
        public static void Main(string[] args)
        {          
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// CreateHostBuilder Method
        /// </summary>
        /// <param name="args"> string[] args </param>
        /// <returns>Returns IHostBuilder</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
