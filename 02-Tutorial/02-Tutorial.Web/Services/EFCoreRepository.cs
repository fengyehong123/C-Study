using _02_Tutorial.Web.Data;
using _02_Tutorial.Web.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _02_Tutorial.Web.Services
{
    public class EFCoreRepository : IRepository<Student>
    {
        private readonly DataContext _context;

        // 通过构造函数的方式把数据库操作类导入
        public EFCoreRepository(DataContext context)
        {
            _context = context;
        }

        public Student Add(Student newModel)
        {
            _context.Students.Add(newModel);
            _context.SaveChanges();

            return newModel;
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);
        }
    }
}
