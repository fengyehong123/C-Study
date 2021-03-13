using _03_Tutorial.Web.Data;
using _03_Tutorial.Web.interfacePackage;
using _03_Tutorial.Web.model;
using _03_Tutorial.Web.servicePackage;
using _03_Tutorial.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.IO;

// 程序运行之后,测试的网址: http://localhost:1937/home/ViewModelTest
namespace _03_Tutorial.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        // 通过构造函数+接口的方式,在Startup类的构造函数中获取配置文件对象
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 通过IServiceCollection接口来实现服务的注册
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");

            // 添加数据库连接类的依赖注入
            services.AddDbContext<DataContext>(options => {
                // 指定使用的数据库类型是SqlServer,同时把连接字符串放进去
                options.UseSqlServer(connectionString);
            });

            // 将Identity认证自己对应的DbContext注入到容器中
            services.AddDbContext<IdentityDbContext>(options => 
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("03-Tutorial.Web"))
            );
            // 注册服务
            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<IdentityDbContext>();
            // 默认的认证服务对密码有一定的要求,我们可以通过下面的方式对其进行配置
            services.Configure<IdentityOptions>(options => {
                // 密码配置
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 1;
                options.Password.RequiredUniqueChars = 1;

            });

            // 通过单例模式来将我们的接口进行注册,在整个项目的生命周期中只会出现一次实例
            services.AddSingleton<IWelComeService, WelcomeService>();

            // 每一次Http请求生成一个实例
            services.AddScoped<IRepository<Student>, EFCoreRepository>();

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

            app.UseWelcomePage(new WelcomePageOptions {
                Path = "/welcome"
            });

            /**
             * 启用静态文件中间件
             * **/
            app.UseStaticFiles();

            /**
             * 以/node_modules开头的请求,中间件会进行处理,可以访问到我们安装的第三方库
             * **/
            app.UseStaticFiles(new StaticFileOptions {
                RequestPath = "/node_modules",
                // 通过项目的路径来获取/node_modules的路径
                FileProvider = new PhysicalFileProvider(Path.Combine(env.ContentRootPath, "node_modules"))
            });

            // 开启认证中间件的使用
            app.UseAuthentication();

            // 由于我们把.UseMvc()中的方法给注释掉了,因此需要手动在Controller类和方法中手动配置路由
            app.UseMvc(builder => {
            
            });

            /**
             * 不管我们收到什么样的HTTP请求,我们都会返回下面的响应
             * 在真实的项目中一般很少使用.run()方法,该方法一般都配置简单的中间件
             * **/
            app.Run(async (context) =>
            {
                var welcomeInfo = welComeService.GetMessage();
                await context.Response.WriteAsync(welcomeInfo);
            });
        }
    }
}
