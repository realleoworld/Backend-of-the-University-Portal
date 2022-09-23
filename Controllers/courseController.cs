using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealleoschoolindAPI.Data;
using RealleoschoolindAPI.Models;

namespace RealleoschoolindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class courseController : Controller
    {
        private readonly StudentIndDbContext _studentIndDbContext;

        public courseController(StudentIndDbContext studentIndDbContext)
        {
            _studentIndDbContext = studentIndDbContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllCourse()
        {
            var course = await _studentIndDbContext.course.ToListAsync();
            return Ok(course);

        }
        
        //[HttpGet]
        //[Route("{courseId}")]
        //public async Task<IActionResult> GetAllDepartment()
        //{
        //    var department = await _studentIndDbContext.course.Select(x => x.CourseName).ToListAsync();
        //    return Ok(department);

        //}

        [HttpPost]
       public async Task<IActionResult> AddCourse([FromBody] course courseRequest )
        {
            var courseNameExistence =
            await _studentIndDbContext.course.Where(x => x.CourseName.Trim().ToLower() == courseRequest.CourseName.Trim().ToLower()).AnyAsync();
            if (!courseNameExistence)
            {
                await _studentIndDbContext.course.AddAsync(courseRequest);
                await _studentIndDbContext.SaveChangesAsync();

                return Json("registered successfully");
            }
            else
            {
                return Json("this course already exists");
                //return HttpResponseJsonExtensions("this course already exists");
            }
        }
        [HttpGet]
        [Route("{courseId}")]
        public async Task<IActionResult> GetStudent([FromRoute] int courseId)
        {
            var course =
           await _studentIndDbContext.course.FirstOrDefaultAsync(x => x.CourseId == courseId);

            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);

        }

        [HttpPut]
        [Route("{courseId}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int courseId, course updateStudentRequest)
        {

            var course = await _studentIndDbContext.course.FindAsync(courseId);

            if (course == null)
            {
                return NotFound();
            }
            course.CourseName = updateStudentRequest.CourseName;
            course.CourseFees = updateStudentRequest.CourseFees;
            course.isDeleted = updateStudentRequest.isDeleted;
            course.isActive = updateStudentRequest.isActive;

            await _studentIndDbContext.SaveChangesAsync();

            return Ok(course);
        }

        [HttpDelete]
        [Route("{courseId}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int courseId)
        {
            var course = await _studentIndDbContext.course.FindAsync(courseId);

            if (course == null)
            {
                return NotFound();
            }

            _studentIndDbContext.course.Remove(course);
            await _studentIndDbContext.SaveChangesAsync();

            return Ok(course);

        }
    }
}
