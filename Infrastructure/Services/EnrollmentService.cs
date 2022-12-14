namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using AutoMapper;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

public class Enrollmentservice
{
    private DataContext _context;
    private IMapper _mapper;

    private readonly IWebHostEnvironment _hostEnvironment;

    public Enrollmentservice(DataContext context, IWebHostEnvironment env, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _hostEnvironment = env;
    }

    public async Task<Response<List<GetEnrollment>>> GetEnrollments()
    {


        var list = await _context.Enrollments.Select(s => new GetEnrollment()
        {
         EnrolmentID=s.EnrolmentID,
            StudentId = s.StudentId,
            CourseId = s.CourseId,
            Grade = s.Grade

        }).ToListAsync();

        return new Response<List<GetEnrollment>>(list);


    }





    public async Task<Response<GetEnrollment>> InsertEnrollment(AddEnrollment enrollment)
    {
     
        var newEnrollment = _mapper.Map<Enrollment>(enrollment);
        //save file 
      
        _context.Enrollments.Add(newEnrollment);
        await _context.SaveChangesAsync();
        var response=_mapper.Map<GetEnrollment>(newEnrollment);
        return  new Response<GetEnrollment> (response);
    }
    public async Task<Response<GetEnrollment>> UpdateEnrollment(AddEnrollment enrollment)
    {

       var find = await _context.Courses.FindAsync(enrollment.EnrolmentID);

     
        find.EnrollmentDate= enrollment.EnrollmentDate;
        
           await _context.SaveChangesAsync();
       var response=_mapper.Map<GetEnrollment>(find);
        return  new Response<GetEnrollment> (response);
    }

    public async Task<Response<string>> DeleteEnrollment(int id)
    {
        var find = await _context.Enrollments.FindAsync(id);
        _context.Enrollments.Remove(find);
        await _context.SaveChangesAsync();
        if (find.EnrolmentID > 0) return new Response<string>("Enrollment deleted successfully");


        return new Response<string>(HttpStatusCode.BadRequest, "Enrollment not found");
    }
}