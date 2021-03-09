using _03_Tutorial.Web.model;
using _03_Tutorial.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_Tutorial.Web.ViewComponents
{
    /**
     * 我们自己定义的组件继承自ViewComponent的父类
     * **/
    public class WelcomeViewComponent: ViewComponent
    {
        private readonly IRepository<Student> _repository;

        public WelcomeViewComponent(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke(int a)
        {
            // a是通过前端传输过来的
            Console.WriteLine(a);

            // 查询所有学生的数量
            var count = _repository.GetAll().Count().ToString();

            /**
             * 注意:
             *  如果我们的count是字符串类型的话,直接当做View的第1个参数的话,就被当成视图的名称进行解析
             *  因此我们需要手动指定一下视图的名称,然后把count当做第2个参数传到View方法中
             * **/
            return View("Default", count);
        }
    }
}
