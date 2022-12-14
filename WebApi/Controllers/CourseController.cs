 using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController
{
    private CourseService _courseService;
    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }
    

    [HttpGet("GetCourse")]
    public async Task<Response<List<GetCourse>>> GetCourse()
    {
        return  await _courseService.GetCourse();
    }
       [HttpPost("InsertCours")]
    public async Task<Response<GetCourse>> InsertCourse([FromForm]AddCourse std)
    {
        return await _courseService.InsertCourse(std);
    }

    [HttpPut("UpdateStudent")]
    public async Task<Response<GetCourse>> UpdateCourse( AddCourse empl)
    {
        return await _courseService.UpdateCourse(empl);
    }
    [HttpDelete("DeleteStudent")]
    public async Task<Response<string>> DeleteCourse(int id)
    {
        return await _courseService.DeleteCourse(id);
    }
}