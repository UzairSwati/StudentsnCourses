using Courses.DBContext;
using Courses.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Services
{
    public class CourseService : ICourseService
    {
        #region Fields
        private readonly CoursesDBContext _coursesDBContext;
        #endregion

        #region Ctor
        public CourseService(CoursesDBContext coursesDBContext)
        {
            _coursesDBContext = coursesDBContext ??
                throw new ArgumentNullException(nameof(coursesDBContext));
        }

        #endregion

        #region Public Methods
        public async Task<int> AddAsync(Course course)
        {
            try
            {
                var res = await _coursesDBContext.Course.AddAsync(course);

                await _coursesDBContext.SaveChangesAsync();

                return res.Entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateAsync(Course course)
        {
            try
            {
                var res = _coursesDBContext.Course.Update(course);

                await _coursesDBContext.SaveChangesAsync();

                return res.Entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Course>> GetAllAsync()
        {
            try
            {

                return Task.FromResult(_coursesDBContext.Course.ToList());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var course = await _coursesDBContext.Course.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (course != null)
                {
                    _coursesDBContext.Course.Remove(course);

                    await _coursesDBContext.SaveChangesAsync();
                }

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
    }
}
