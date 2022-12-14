 using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController
{
    private StudentService _studentService;
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }
    

    [HttpGet("GetStudent")]
    public async Task<Response<List<GetStudent>>> GetStudent()
    {
        return  await _studentService.GetStudent();
    }
       [HttpPost("InsertStudent")]
    public async Task<Response<GetStudent>> InsertStudent([FromForm]AddStudent std)
    {
        return await _studentService.InsertStudent(std);
    }

    [HttpPut("UpdateStudent")]
    public async Task<Response<GetStudent>> UpdateStudent([FromForm] AddStudent empl)
    {
        return await _studentService.UpdateStudent(empl);
    }
    [HttpDelete("DeleteStudent")]
    public async Task<Response<string>> DeleteStudent(int id)
    {
        return await _studentService.DeleteStudent(id);
    }
}