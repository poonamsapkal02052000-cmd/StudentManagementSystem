using StudentManagementSystem.Models;
using StudentManagementSystem.Repositories;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await _repository.GetAllStudents();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _repository.GetStudentById(id);
        }

        public async Task<Student> AddStudent(Student student)
        {
            return await _repository.AddStudent(student);
        }

        public async Task<Student> UpdateStudent(int id, Student student)
        {
            var existingStudent = await _repository.GetStudentById(id);

            if (existingStudent == null)
            {
                return null;
            }

            existingStudent.Name = student.Name;
            existingStudent.Email = student.Email;
            existingStudent.Age = student.Age;
            existingStudent.Course = student.Course;

            return await _repository.UpdateStudent(existingStudent);
        }

        public async Task<bool> DeleteStudent(int id)
        {
            return await _repository.DeleteStudent(id);
        }
    }
}