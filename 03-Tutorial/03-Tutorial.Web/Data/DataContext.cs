using _03_Tutorial.Web.model;
using Microsoft.EntityFrameworkCore;

namespace _03_Tutorial.Web.Data
{
    /**
     * EF Core通过继承DbContext的类来操作数据库
     * 我们一般使用依赖注入的方式来创建这个ORM连接类
     * 在Startup的处进行依赖注入
     * **/
    public class DataContext: DbContext
    {
        /**
         * 泛型写类本身
         * 把options传递给父类(base(options))
         * **/
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        /**
         * 每一个DbSet都会和数据库中的一个表对应,形成映射关系
         * **/
        public DbSet<Student> Students { get; set; }
    }
}
