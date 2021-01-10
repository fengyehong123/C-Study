using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_Tutorial.Web.Controllers
{
    /// <summary>
    /// [Route("v2/[controller]/[action]")]
    ///     路由的简便写法
    /// 我们可以通过
    ///             /v2/Work/Name
    ///             /v2/Work/Address
    /// 来访问对应的方法
    /// </summary>
    [Route("v2/[controller]/[action]")]
    public class WorkController
    {
        public string Name()
        {
            return "我的名字是贾飞天";
        }

        public string Address()
        {
            return "地球";
        }
    }
}
