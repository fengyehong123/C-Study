using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _01_Tutorial.Web.model
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BrithDate { get; set; }

        // 返回一个性别枚举类
        public Gender Gender { get; set; }
    }
}
