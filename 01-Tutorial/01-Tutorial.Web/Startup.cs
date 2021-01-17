using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_Tutorial.Web.interfacePackage;
using _01_Tutorial.Web.model;
using _01_Tutorial.Web.servicePackage;
using _01_Tutorial.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace _01_Tutorial.Web
{
    public class Startup
    {
        /// <summary>
        /// 通过IServiceCollection接口来实现服务的注册
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // 通过单例模式来将我们的接口进行注册,在整个项目的生命周期中只会出现一次实例
            services.AddSingleton<IWelComeService, WelcomeService>();
            services.AddSingleton<IRepository<Student>, InMemoryRepository>();

            // (将我们的接口进行注册)每一次web请求都会创建一个实例
            // services.AddScoped<IRepository<Student>, InMemoryRepository>();

            // 每次有方法请求IWelComeService接口的时候,都会创建一个实例
            // services.AddTransient<IWelComeService, WelcomeService>();

            // 注册MVC服务,MVC的服务不是默认添加的,我们需要手动添加一下
            services.AddMvc();
        }

        /// <summary>
        /// 配置了HTTP请求的管道,每当一个HTTP请求到达之后,Configure方法里面的组件将决定
        /// 我们如何响应HTTP请求
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="configuration"></param>
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env,
            /**
             * 在方法的参数中,添加了IConfiguration接口
             * 相当于请求实现了IConfiguration接口的对象所对应的服务
             * 为什么可以在方法的参数中直接请求实现了IConfiguration接口的对象呢?
             * 因为ASP.Net Core使用依赖注入,在整个应用几乎所有的地方都可以使用依赖注入
             * 原理:
             *      当web程序调用Configure方法的时候,ASP.Net Core会分析方法的参数
             *      当前方法请求了三个参数app,env,configuration
             *      如果ASP.Net Core能自动解析这些参数的话,ASP.Net Core会自动把实现了
             *      该接口的对象(服务)传递到此处,供方法中进行调用
             * **/
            // IConfiguration configuration

            // 使用我们自己定义的接口,我们自己定义的接口需要通过IServiceCollection接口手动注入到容器当中
            IWelComeService welComeService,
            // 导入日志接口,因为AspNetCore已经把这个类注入好了,因此我们可以无需注册就直接使用
            ILogger<Startup> logger
            )
        {
            /**
             * 如果当前是开发模式,就启用异常页,
             * 如果不启用该页的话,就会返回一个500的异常状态码
             * **/
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // 如果非开发模式的话,走下面这个中间件
                app.UseExceptionHandler();
            }

            /**
             * app.Use()是一种比较底层的调用中间件的方法
             * 在程序执行的时候,app.Use只会执行一次,
             * 但是在该方法中return后面的部分才是中间件,
             * 中间件方法会执行多次
             * **/
            app.Use(next => {

                logger.LogInformation("app.Use().....");
                return async httpContext =>
                {
                    logger.LogInformation("---async httpContext");

                    // 当请求以/first开头的时候就会返回到页面"First!!!"字符串
                    if (httpContext.Request.Path.StartsWithSegments("/first"))
                    {
                        logger.LogInformation("---First!!!");
                        await httpContext.Response.WriteAsync("First!!!");
                    }
                    else
                    {
                        logger.LogInformation("next(httpContext)");

                        // 否则就继续执行下面的中间件
                        await next(httpContext);
                    }
                };
            });

            /**
             * 在真实的项目中我们一般使用.UseXXX()开头的中间件
             * app.UseWelcomePage(): 启用欢迎页
             *      1. 默认的配置是收到任何请求都会显示这个欢迎页,后面的中间件就不再执行了
             *      2. 但是我们对UseWelcomePage方法进行了配置,只有当URL是"/welcome"的时候才会显示该中间件
             *         否则就继续执行后面的中间件
             * **/
            app.UseWelcomePage(new WelcomePageOptions {
                Path = "/welcome"
            });

            /**
             * 这个中间件的作用相当于UseDefaultFiles()和UseStaticFiles()
             * **/
            // app.UseFileServer();
            /**
             * 启用默认文件中间件,默认是wwwroot文件夹
             * **/
            //app.UseDefaultFiles();
            /**
             * 启用静态文件中间件
             * **/
            app.UseStaticFiles();

            /**
             * 使用默认路由的MVC,该MVC会有默认的路由配置规则
             *  当访问项目根路径的时候会找到HomeController类中的Index方法
             * **/
            // app.UseMvcWithDefaultRoute();

            // 由于我们把.UseMvc()中的方法给注释掉了,因此需要手动在Controller类和方法中手动配置路由
            app.UseMvc(builder => {
                /**
                 * 当我们访问 /Home/Index/3 的时候,会通过下面的路由配置
                 * 找到HomeController类中的Index()方法
                 * {controller}/{action}/{id?}中的id?代表id是可选的
                 * **/
                // builder.MapRoute("Default", "{controller}/{action}/{id?}");

                // 给路由设置默认值,如果我们访问项目的根路径的话,就会默认访问/Home/Index
                // builder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");

                /**
                 * 上面这两种方式要求路由的名称和类名称和方法名要对应起来
                 * 我们还可以像java中在类上添加路由标签的方式来实现路由的配置
                 * **/
            });

            /**
             * 不管我们收到什么样的HTTP请求,我们都会返回下面的响应
             * 在真实的项目中一般很少使用.run()方法,该方法一般都配置简单的中间件
             * **/
            app.Run(async (context) =>
            {
                /**
                 * 从配置文件中读取配置信息
                 * 获取配置信息有优先级,同名的情况下,先加载的会被后加载的给覆盖掉
                 * 1. appsettings.json (最先加载)
                 * 2. appsettings.Development.json
                 * 3. User Secrets
                 * 4. 环境变量
                 * 5. 命令行参数(最后加载)
                 * **/
                // var welcomeInfo = configuration["Welcome"];

                var welcomeInfo = welComeService.GetMessage();
                await context.Response.WriteAsync(welcomeInfo);
            });
        }
    }
}
