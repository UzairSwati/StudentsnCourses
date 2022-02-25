using Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Services
{
    public interface ICourseService
    {
        Task<int> AddAsync(Course student);
        Task<List<Course>> GetAllAsync();
    }
}
