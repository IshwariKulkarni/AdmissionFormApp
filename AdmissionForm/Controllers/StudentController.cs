using AdmissionForm.Dto;
using AdmissionForm.Interface;
using AdmissionForm.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdmissionForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _studentRepo;

        public StudentController(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            try
            {
                var existingStudent = await _studentRepo.GetStudentByEmailAsync(studentDto.Email);

                if (existingStudent != null)
                {
                    // Email already exists
                    return BadRequest("Email already exists.");
                }

                var student = await _studentRepo.AddStudentAsync(studentDto);

                // Return created student
                return CreatedAtAction("GetStudents", new { id = student.Id }, student);
/*                return Ok(student);*/
            }
            catch (Exception ex)
            {
                
                // Log or handle the exception appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }

        [HttpGet("GetStudents")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
                var students = await _studentRepo.GetStudentsAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
    }
}
