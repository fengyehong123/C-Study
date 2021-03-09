using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_Tutorial.Web.Controllers
{
    /// <summary>
    /// [Route("about")]添加路由,当访问/about路由的时候,会找到AboutController类
    /// 因为Me()方法上路由标签配置为
    ///     [Route("")],所以默认会通过/about访问到Me方法
    ///     [Route("company")],所以默认会通过/about/company访问到Company方法
    /// </summary>
    [Route("about")]
    public class AboutController
    {
        [Route("")]
        public string Me()
        {
            return "我的名字是枫叶红";
        }

        [Route("company")]
        public string Company()
        {
            return "自由职业者";
        }
    }
}
