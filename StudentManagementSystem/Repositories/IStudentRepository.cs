using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repositories
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudents();

        Task<Student> GetStudentById(int id);

        Task<Student> AddStudent(Student student);

        Task<Student> UpdateStudent(Student student);

        Task<bool> DeleteStudent(int id);
    }
}