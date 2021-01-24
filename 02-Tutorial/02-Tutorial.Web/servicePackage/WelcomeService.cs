using _02_Tutorial.Web.interfacePackage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Tutorial.Web.servicePackage
{
    /// <summary>
    /// 定义一个类来实现接口中的方法
    /// </summary>
    public class WelcomeService : IWelComeService
    {
        public string GetMessage()
        {
            return "Hello from IWelcome service";
        }
    }
}
