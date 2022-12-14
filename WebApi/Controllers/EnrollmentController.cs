 using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class EnrollmenrController
{
    private Enrollmentservice _enrolService;
    public EnrollmenrController(Enrollmentservice enrolService)
    {
        _enrolService = enrolService;
    }
    

    [HttpGet("GetEnrollment")]
    public async Task<Response<List<GetEnrollment>>> GetEnrollment()
    {
        return  await _enrolService.GetEnrollments();
    }
       [HttpPost("InsertEnrollment")]
    public async Task<Response<GetEnrollment>> InsertEnrollment([FromForm]AddEnrollment std)
    {
        return await _enrolService.InsertEnrollment(std);
    }

    [HttpPut("UpdateStudent")]
    public async Task<Response<GetEnrollment>> UpdateEnrollment( AddEnrollment empl)
    {
        return await _enrolService.UpdateEnrollment(empl);
    }
    [HttpDelete("DeleteStudent")]
    public async Task<Response<string>> DeleteEnrollment(int id)
    {
        return await _enrolService.DeleteEnrollment(id);
    }
}