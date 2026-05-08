using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface IStudentService
    {
        Task<List<Student>> GetAllStudents();

        Task<Student> GetStudentById(int id);

        Task<Student> AddStudent(Student student);

        Task<Student> UpdateStudent(int id, Student student);

        Task<bool> DeleteStudent(int id);
    }
}