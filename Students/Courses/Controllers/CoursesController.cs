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
                if (course == null)
                {
                    return BadRequest("Course is null");
                }

                if (course.TotalMarks < course.ObtainedMarks)
                {
                    return BadRequest("Total marks should be greater than obtained marks");
                }

                if (string.IsNullOrEmpty(course.Name))
                {
                    return BadRequest("Name is empty");
                }

                if (course.StudentId == 0)
                {
                    return BadRequest("StudentId is Zero");
                }

                var id = await _courseService.AddAsync(course);

                return Ok(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetAsync([FromRoute] int id)
        {
            try
            {
                var response = await _courseService.GetAsync(id);

                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult> GetAllAsync()
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int id)
        {
            try
            {
                var response = await _courseService.DeleteAsync(id);

                return Ok(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateAsync([FromBody] Course course)
        {
            try
            {
                if (course == null)
                {
                    return BadRequest("Course is null");
                }

                if (course.TotalMarks < course.ObtainedMarks)
                {
                    return BadRequest("Total marks should be greater than obtained marks");
                }

                if (string.IsNullOrEmpty(course.Name))
                {
                    return BadRequest("Name is empty");
                }

                if (course.StudentId == 0)
                {
                    return BadRequest("StudentId is Zero");
                }

                var id = await _courseService.UpdateAsync(course);

                return Ok(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region Private Methods
        #endregion
    }
}
