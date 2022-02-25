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

                return res.Entity.Id;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async  Task<List<Student>> GetAllAsync()
        {
            try
            {
                var res = await _studentsDBContext.Student.Where(x => x.Id == 33).FirstOrDefaultAsync();

                return _studentsDBContext.Student.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion
    }
}
