using System;
using System.Collections.Generic;

namespace _01_Tutorial.Web.Services
{
    // 使用泛型定义一个接口
    public interface IRepository<T> where T: class
    {
        // 接口中的方法返回一个集合
        IEnumerable<T> GetAll();

        T GetById(int id);
    }
}
