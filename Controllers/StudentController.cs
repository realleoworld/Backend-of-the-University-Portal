using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealleoschoolindAPI.Data;
using RealleoschoolindAPI.Models;

namespace RealleoschoolindAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    
    public class StudentController : Controller
    {
        private readonly StudentIndDbContext _studentIndDbContext;

        public StudentController(StudentIndDbContext studentIndDbContext)
        {
            _studentIndDbContext = studentIndDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
          var student = await  _studentIndDbContext.Student.OrderBy(x => x.isActive == false).ToListAsync();

            return Ok(student);
        }


        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] Student studentRequest)
        {

            studentRequest.isActive = true;
           var emailExistsAsync = 
                await _studentIndDbContext.Student.Where(x => x.Email == studentRequest.Email || x.Phone
                == studentRequest.Phone).FirstOrDefaultAsync();
            if (emailExistsAsync == null)
            {
                
                await _studentIndDbContext.Student.AddAsync(studentRequest);
                await _studentIndDbContext.SaveChangesAsync();

                return Ok(studentRequest);
            }
            else
            {
                return Ok(null);
            }
         
        }

        [HttpPost]
        [Route("authenticate")]
        public async Task<IActionResult> AuthenticateStudent([FromBody] Student studentRequest)
        {
            var student =
                 await _studentIndDbContext.Student.Where(x => x.Id == studentRequest.Id && x.password
                 == studentRequest.password).FirstOrDefaultAsync();
            if (student != null)
            {

                return Ok(student);
            }
            else
            {
                return Ok(null);
            }

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            var student =
           await _studentIndDbContext.Student.FirstOrDefaultAsync(x => x.Id == id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id, Student updateStudentRequest)
        {

          var student = await  _studentIndDbContext.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            student.firstName = updateStudentRequest.firstName;
            student.lastName = updateStudentRequest.lastName;
            student.password = updateStudentRequest.password;
            student.Email = updateStudentRequest.Email;
            student.Department = updateStudentRequest.Department;
            student.Phone = updateStudentRequest.Phone;

          await  _studentIndDbContext.SaveChangesAsync();

            return Ok(student);
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            var student = await _studentIndDbContext.Student.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            student.isActive = false;

            //_studentIndDbContext.Student.Remove(student);
            await _studentIndDbContext.SaveChangesAsync();

            return Ok(student);

        }
    }
}
