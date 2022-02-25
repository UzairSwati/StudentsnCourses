using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Students.Models;
using Students.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        #region Fields
        private readonly IStudentService _studentService;
        #endregion

        #region Ctor
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService ??
                 throw new ArgumentNullException(nameof(studentService));
        }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student is null");
                }

                if (student.RollNo == 0)
                {
                    return BadRequest("RollNo is Zero");
                }

                if (string.IsNullOrEmpty(student.Name))
                {
                    return BadRequest("Name is empty");
                }

                var id = await _studentService.AddAsync(student);

                return Ok(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Student>>> GetAllAsync()
        {
            try
            {
                var response = await _studentService.GetAllAsync();

                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var response = await _studentService.DeleteAsync(id);

                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] Student student)
        {
            try
            {
                if (student == null)
                {
                    return BadRequest("Student is null");
                }

                if (student.Id == 0)
                {
                    return BadRequest("StudentId is Zero");
                }

                if (student.RollNo == 0)
                {
                    return BadRequest("RollNo is Zero");
                }

                if (string.IsNullOrEmpty(student.Name))
                {
                    return BadRequest("Name is empty");
                }

                var id = await _studentService.UpdateAsync(student);

                return Ok(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
