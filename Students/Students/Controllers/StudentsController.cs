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
            _studentService = studentService;
        }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] Student student)
        {
            try
            {
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
        #endregion

    }
}
