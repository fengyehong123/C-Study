using _01_Tutorial.Web.model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_Tutorial.Web.Controllers
{
    /// <summary>
    /// 我们自定义的类继承了MVC自带的Controller类,该类中包含了很多上下文信息
    /// 我们可以在自己定义的类中使用这些上下文信息
    /// </summary>
    [Route("home")]
    public class HomeController: Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            // 通过上下文对象获取类的名称
            string controllerName = this.ControllerContext.ActionDescriptor.ControllerName;

            // 因为继承了MVC的Controller类,可以直接获返回相应结果
            this.Ok();
            this.BadRequest();
            this.NotFound();

            // 还可以返回文件
            // this.File();

            var student = new Student
            {
                Id = 1,
                FirstName = "Nick",
                LastName = "Carter"
            };

            /**
             * 我们将学生信息放到ObjectResult()对象中
             * 在浏览器侧,得到的是一个json对象
             * { "id":1,"firstName":"Nick","lastName":"Carter"}
             * **/
            return new ObjectResult(student);
        }

        [Route("ViewTest")]
        public IActionResult ViewTest()
        {
            var student = new Student
            {
                Id = 1,
                FirstName = "Nick",
                LastName = "Carter"
            };

            /**
             * 我们只返回View()不加任何字符串参数的话,会寻找方法名所对应的视图
             *      => /Views/Home/ViewTest.cshtml(Views文件夹下的Home文件夹下的ViewTest.cshtml文件)
             * 返回View("Student")的话,会寻找Student视图 
             *      => /Views/Home/Student.cshtml(Views文件夹下的Home文件夹下的Student.cshtml文件)
             * **/
            // 把student参数传递到视图当中
            return View(student);
        }

        /**
         * 使用IActionResult这个返回类型,更加的灵活,更加的容易扩展
         * 如果我们返回一个字符串的话,mvc会直接把字符串返回给前端
         * 但是我们使用this.Content("字符串")来返回字符串的话
         *  并不会直接把字符串返回到前端,因为该方法返回的是一个IActionResult类型
         *  方法只是决定要把字符串返回给前端,实际上并没有这么做
         *  MVC框架看到返回值是IActionResult类型,就知道要该方法要返回数据到前端
         *  在后续的管道的处理中就会通过某些处理把结果返回到前端
         *  
         *  决定做什么事情和真正做事情是分开的
         *  方法决定做什么事,真正做事的是框架
         * **/
        public IActionResult Test()
        {
            // 直接返回文字
            return this.Content("Hello from HomeController Test method");
            
        }
    }
}
