using Microsoft.EntityFrameworkCore;
using Students.DBContext;
using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Services
{
    public class StudentService : IStudentService
    {
        #region Fields
        private readonly StudentsDBContext _studentsDBContext;
        #endregion

        #region Ctor
        public StudentService(StudentsDBContext studentsDBContext)
        {
            _studentsDBContext = studentsDBContext ??
                throw new ArgumentNullException(nameof(studentsDBContext));
        }

        #endregion

        #region Public Methods
        public async Task<int> AddAsync(Student student)
        {
            try
            {
                var res = await _studentsDBContext.Student.AddAsync(student);

                await _studentsDBContext.SaveChangesAsync();

                return res.Entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> UpdateAsync(Student student)
        {
            try
            {
                var res = _studentsDBContext.Student.Update(student);

                await _studentsDBContext.SaveChangesAsync();

                return res.Entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<List<Student>> GetAllAsync()
        {
            try
            {
                return Task.FromResult(_studentsDBContext.Student.ToList());
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
                var student = await _studentsDBContext.Student.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (student != null)
                {
                    _studentsDBContext.Student.Remove(student);
                }

                await _studentsDBContext.SaveChangesAsync();

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
