using Courses.Models;
using Courses.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Courses.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CoursesController : ControllerBase
    {
        #region Fields
        private readonly ICourseService _courseService;
        #endregion

        #region Ctor
        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService ??
                throw new ArgumentNullException(nameof(courseService));
        }
        #endregion

        #region Actions
        [HttpPost]
        public async Task<ActionResult> AddAsync([FromBody] Course course)
        {
            try
            {
                var id = await _courseService.AddAsync(course);

                return Ok(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Course>>> GetAllAsync()
        {
            try
            {
                var response = await _courseService.GetAllAsync();

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
