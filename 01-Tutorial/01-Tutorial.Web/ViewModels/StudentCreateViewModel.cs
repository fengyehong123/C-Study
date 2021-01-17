using _01_Tutorial.Web.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_Tutorial.Web.ViewModels
{
    public class StudentCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BrithDate { get; set; }
        // 返回一个性别枚举类
        public Gender Gender { get; set; }
    }
}
