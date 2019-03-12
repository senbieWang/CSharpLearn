using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace aspnetcoreLearn
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //采用 builder pattern 
            CreateWebHostBuilder(args).Build().Run();
        }

        //build  host 对象，通过Startup中的信息来构件该host对象
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
