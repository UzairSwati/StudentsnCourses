using Microsoft.EntityFrameworkCore;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.DBContext
{
    public class StudentsDBContext : DbContext
    {
        public StudentsDBContext()
        {

        }
        public StudentsDBContext(DbContextOptions<StudentsDBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }


    }
}
