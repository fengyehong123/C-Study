using _01_Tutorial.Web.model;
using _01_Tutorial.Web.Services;
using _01_Tutorial.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace _01_Tutorial.Web.Controllers
{
    /// <summary>
    /// 我们自定义的类继承了MVC自带的Controller类,该类中包含了很多上下文信息
    /// 我们可以在自己定义的类中使用这些上下文信息
    /// </summary>
    [Route("home")]
    public class HomeController: Controller
    {
        // 一般通过这样一个只读属性的对象接收注入的对象
        private readonly IRepository<Student> _repository;

        // 一般通过构造函数的方式进行接口注入
        public HomeController(IRepository<Student> repository)
        {
            _repository = repository;
        }

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
            // 使用我们注册好的接口,获取所有的学生数据
            var studentList = _repository.GetAll();

            /**
             * 我们只返回View()不加任何字符串参数的话,会寻找方法名所对应的视图
             *      => /Views/Home/ViewTest.cshtml(Views文件夹下的Home文件夹下的ViewTest.cshtml文件)
             * 返回View("Student")的话,会寻找Student视图 
             *      => /Views/Home/Student.cshtml(Views文件夹下的Home文件夹下的Student.cshtml文件)
             * **/
            // 把studentList参数传递到视图当中
            return View(studentList);
        }

        [Route("ViewModelTest")]
        public IActionResult ViewModelTest()
        {
            // 使用我们注册好的接口,获取所有的学生数据
            var studentList = _repository.GetAll();
            // 把Student实体类转换为StudentViewModel实体类
            var vms = studentList.Select(x => new StudentViewModel
            {
                Id = x.Id,
                Name = $"{x.FirstName} {x.LastName}",
                Age = DateTime.Now.Subtract(x.BrithDate).Days / 365
            });

            var vm = new HomeIndexViewModel
            {
                Students = vms
            };

            return View(vm);
        }

        /**
         * {id?}表示此参数可有可无
         * 
         * 下面这两种方式都可以把URL中的id自动封装到Detail(int id)中的id中
         * /home/detail?id=1
         * /home/detail/1 
         * 
         * 如果是下面的这种方式的话,只会封装1,而不会封装2
         * /home/detail/1?id=2
         * 
         * **/
        [Route("Detail/{id?}")]
        public IActionResult Detail(int id)
        {
            var student = _repository.GetById(id);
            if(student == null)
            {
                // 跳转到本Controller的Index方法
                return RedirectToAction("Index");
            }
            return View(student);
        }

        [Route("Create")]
        [HttpGet]  // 默认就是get方法
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]  // 指定请求为post方法
        [ValidateAntiForgeryToken]  // 针对post表单提交要加上这个注解,因为前端会放置一个隐藏域,表单提交的时候会把隐藏域提交,防止跨站请求伪造
        public IActionResult Create(StudentCreateViewModel student)
        {
            // 如果StudentCreateViewModel中添加注解的属性字段通过了验证的话
            if (ModelState.IsValid)
            {
                var newStudent = new Student
                {
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    BrithDate = student.BrithDate,
                    Gender = student.Gender
                };

                var newModel = _repository.Add(newStudent);

                // 将student对象序列化为json字符串返回到前端
                // return this.Content(JsonConvert.SerializeObject(student));

                // 将添加成功的对象在Detail视图页面进行展示
                // return View("Detail", newModel);

                /**
                 * nameof(Detail)就相当于 "Detail"字符串,使用nameof的话,有利于重构
                 * 因为Detail方法需要一个参数,所以我们通过匿名类的方式传递参数id
                 * 
                 * 之所以不使用 View("Detail", newModel);的方式
                 * 而使用RedirectToAction(nameof(Detail), new { id = newModel.Id})的方式
                 * 是想等到student对象添加成功之后进行重定向改变浏览器的url,防止浏览器刷新造成多次表单提交
                 * **/
                return RedirectToAction(nameof(Detail), new { id = newModel.Id });
            }

            // 如果没有通过验证还是显示原来的视图
            return View();
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
