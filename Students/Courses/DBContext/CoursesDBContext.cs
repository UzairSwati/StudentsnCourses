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

        public virtual DbSet<Course> Course { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasColumnName("NAME")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StudentId).HasColumnName("ROLL_NO");
                entity.Property(e => e.TotalMarks).HasColumnName("TOTAL_MARKS");
                entity.Property(e => e.ObtainedMarks).HasColumnName("OBTAINED_MARKS");
            });
        }

    }
}
