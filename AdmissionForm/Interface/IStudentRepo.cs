using AdmissionForm.Dto;
using AdmissionForm.Models;

namespace AdmissionForm.Interface
{
    public interface IStudentRepo
    {
        Task<Student> AddStudentAsync(StudentDto studentDto);
        Task<IEnumerable<Student>> GetStudentsAsync();

        Task<Student> GetStudentByEmailAsync(string email); 
    }
}
