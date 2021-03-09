using _03_Tutorial.Web.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _03_Tutorial.Web.Services
{
    public class InMemoryRepository : IRepository<Student>
    {
        private readonly List<Student> _students;

        // 创建一个构造函数,在构造函数中构造好Student列表
        public InMemoryRepository()
        {
            _students = new List<Student>
            {
                    new Student{ Id = 1, FirstName = "Nick", LastName = "Carter", BrithDate = new DateTime(1980, 1, 4) },
                    new Student{ Id = 2, FirstName = "Kevin", LastName = "Richardson", BrithDate = new DateTime(1974, 6, 16) },
                    new Student{ Id = 3, FirstName = "Mike", LastName = "Json", BrithDate = new DateTime(1978, 12, 5) }
            };
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            // 通过ID查询对应的Student实体类
            return _students.FirstOrDefault(x => x.Id == id);
        }

        // 把添加之后的Student类型返回
        public Student Add(Student newModel)
        {
            // 模拟id自增
            var maxId = _students.Max(x => x.Id);  // 获取出最大的id
            newModel.Id = maxId + 1;

            _students.Add(newModel);

            return newModel;
        }
    }
}
