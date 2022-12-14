using System.Net;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Context;
using AutoMapper;

namespace Infrastructure.Services;

public class CourseService
{
    private readonly DataContext _context;

       private readonly IMapper _mapper;


    public CourseService(DataContext context,IMapper mapper)
    {
        _context = context;
           _mapper = mapper;
        
    }

     public async Task<Response<List< GetCourse>>> GetCourse()
        {       
       var list = await _context.Courses.Select(j => new GetCourse()
        {   CourseID=j.CourseID,
            Title=j.Title,
            Credit=j.Credit,
            EnrollmentDate=j.EnrollmentDate
          
        
        }).ToListAsync();

        return new Response<List<GetCourse>>(list);
        }
    public async Task<Response<GetCourse>> InsertCourse(AddCourse course)
    {
       
        var newCourse = _mapper.Map<Course>(course);
        //save file 
      
        _context.Courses.Add(newCourse);
        await _context.SaveChangesAsync();
        var response=_mapper.Map<GetCourse>(newCourse);
        return  new Response<GetCourse> (response);

      
    }
   public async  Task<Response<GetCourse>> UpdateCourse(AddCourse course)
        {
  var find = await _context.Courses.FindAsync(course.CourseID);

        find.Title = course.Title;
        find.Credit = course.Credit;
        find.EnrollmentDate= course.EnrollmentDate;
           await _context.SaveChangesAsync();
       var response=_mapper.Map<GetCourse>(find);
        return  new Response<GetCourse> (response);
            }
        
         public async Task<Response<string>> DeleteCourse(int id)
        {      
        var find = await _context.Courses.FindAsync(id);
        _context.Courses.Remove(find);
        await _context.SaveChangesAsync();
           if(find != null)  return new Response<string>("Courses deleted successfully");

        
               return new Response<string>(HttpStatusCode.BadRequest, "Courses not found");
        }
}
