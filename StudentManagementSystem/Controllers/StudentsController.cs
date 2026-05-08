using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _service.GetAllStudents();

            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _service.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student not found");
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            var result = await _service.AddStudent(student);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            var result = await _service.UpdateStudent(id, student);

            if (result == null)
            {
                return NotFound("Student not found");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _service.DeleteStudent(id);

            if (!result)
            {
                return NotFound("Student not found");
            }

            return Ok("Student deleted successfully");
        }
    }
}