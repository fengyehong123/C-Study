using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace _03_Tutorial.Web
{
    /// <summary>
    /// Program这个类主要配置的是web应用的基础设施
    /// 例如HTTP服务器和集成到IIS和配置源等信息
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// 通过IWebHostBuilder来设置web服务
        /// CreateDefaultBuilder是默认的设置,我们可以在该类中进行配置改变默认的设置
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                /**
                 * 我们在此处注册Startup这个类,通过这个类来配置web应用的启动逻辑
                 * AspNetCore会实例化这个类,并调用这个类里面的两个方法
                 *      ConfigureServices: 
                 *          进行服务的注册,注册成功后就可以注入到其他方法或者类中使用了
                 *      Configure: 
                 *          这个方法只会执行一次,通过该方法中的IApplicationBuilder接口来实现中间件的配置
                 * **/
                .UseStartup<Startup>();
    }
}
