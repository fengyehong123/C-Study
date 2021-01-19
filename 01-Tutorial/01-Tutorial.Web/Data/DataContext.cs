using _01_Tutorial.Web.model;
using Microsoft.EntityFrameworkCore;

namespace _01_Tutorial.Web.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
