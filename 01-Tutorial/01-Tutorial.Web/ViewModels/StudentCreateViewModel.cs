using _01_Tutorial.Web.model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _01_Tutorial.Web.ViewModels
{
    public class StudentCreateViewModel
    {
        /**
         * 如果前端的Label绑定了实体类的值的话,就会找Display对应的注解显示在Label标签上
         * 如果对应的属性没有Display注解的话,就会把属性名称FirstName显示在前端上
         * **/
        [Display(Name = "名")]
        [Required]  // 标识该属性不能为空
        public string FirstName { get; set; }

        [Display(Name = "姓"), Required, MaxLength(10)]  // 多个注解可以写在一行上
        public string LastName { get; set; }

        [Display(Name = "出生日期")]
        public DateTime BrithDate { get; set; }


        // 返回一个性别枚举类
        [Display(Name = "性别")]
        public Gender Gender { get; set; }

        /**
         * 标识该属性为密码,如果前端用input绑定了该属性,则会显示密码框
         * **/
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
