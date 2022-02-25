using Courses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.DBContext
{
    public class CoursesDBContext : DbContext
    {
        public CoursesDBContext()
        {

        }
        public CoursesDBContext(DbContextOptions<CoursesDBContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        => dbContextOptionsBuilder.UseSqlServer("Server=TOSHIBA\\SQLEXPRESS;user id=sa;pwd=admin;Database=StudentsData;");

    }
}
