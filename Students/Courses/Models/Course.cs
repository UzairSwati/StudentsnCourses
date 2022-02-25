using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalMarks { get; set; } = 100;
        public int ObtainedMarks { get; set; }
        public int StudentId { get; set; }
    }
}
