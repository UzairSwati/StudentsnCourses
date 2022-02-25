using Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Services
{
    public interface ICourseService
    {
        Task<int> AddAsync(Course course);
        Task<int> UpdateAsync(Course course);
        Task<List<Course>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
