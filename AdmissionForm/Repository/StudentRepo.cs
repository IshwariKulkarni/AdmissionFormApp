using AdmissionForm.AdmissionApp;
using AdmissionForm.Controllers;
using AdmissionForm.Dto;
using AdmissionForm.Interface;
using AdmissionForm.Models;
using Microsoft.EntityFrameworkCore;

namespace AdmissionForm.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _context;
        private readonly ILogger<StudentController> _logger;


        public StudentRepo(AppDbContext context, ILogger<StudentController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Student> AddStudentAsync(StudentDto studentDto)
        {
            try
            {
                
                var student = new Student
                {
                    Name = studentDto.Name,
                    MothersName = studentDto.MothersName,
                    Email = studentDto.Email,
                    DOB = studentDto.DOB,
                    Class = studentDto.Class,
                    StateId = studentDto.StateId,
                    City = studentDto.City,
                    Pincode = studentDto.Pincode,
                    Gender = studentDto.Gender,
                    Category = studentDto.Category
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                return student;
            }
            catch (Exception ex)
            {
                // Log or handle the exception appropriately
                throw new Exception("Error adding student", ex);
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Student> GetStudentByEmailAsync(string email) 
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.Email == email);
        }
    }
}
