using _01_Tutorial.Web.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _01_Tutorial.Web.Services
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
    }
}
