using System;
using System.Collections.Generic;
using _02_Tutorial.Web.model;

namespace _02_Tutorial.Web.Services
{
    // 使用泛型定义一个接口 Ctrl + F12 可以快速定位到接口的实现类
    public interface IRepository<T> where T: class
    {
        // 接口中的方法返回一个集合
        IEnumerable<T> GetAll();

        // 根据id进行查询
        T GetById(int id);

        // 添加一个Model对象
        T Add(T newModel);
    }
}
