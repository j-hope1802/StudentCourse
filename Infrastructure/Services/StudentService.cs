namespace Infrastructure.Services;
using Domain.Entities;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AutoMapper;

public class StudentService
{
    private DataContext _context;

   private readonly IWebHostEnvironment _hostEnvironment;
       private readonly IMapper _mapper;

    public StudentService(DataContext context,IWebHostEnvironment env,IMapper mapper)
    {
        _context = context;
        _hostEnvironment = env;
         _mapper = mapper;
    }

    public async Task<Response<List<GetStudent>>> GetStudent()
    {
        
    
        var list = await _context.Students.Select(s => new GetStudent()
        {
           ID=s.ID,
           FirstName=s.FirstName,
           LastName=s.LastName,
           ImageName =  s.ImageName


        }).ToListAsync();

        return new Response<List<GetStudent>>(list);
            
    }
    
    public async Task<Response<GetStudent>> InsertStudent(AddStudent student)
    {
       
        var newStudent = _mapper.Map<Student>(student);
        //save file 
        newStudent.ImageName = await UploadFile(student.Image);
        _context.Students.Add(newStudent);
           await _context.SaveChangesAsync();
        var response=_mapper.Map<GetStudent>(newStudent);
        return  new Response<GetStudent> (response);

      
    }
        public async Task<Response<GetStudent>> UpdateStudent(AddStudent student)
        {
  
             var find = await _context.Students.FindAsync(student.ID);
        find.FirstName = student.FirstName;
        find.LastName = student.LastName;
        find.EnrollmentDate= student.EnrollmentDate;

        if (student.Image != null)
        {
            find.ImageName = await UpdateFile(student.Image, find.ImageName);
        }
          await _context.SaveChangesAsync();
       var response=_mapper.Map<GetStudent>(find);
        return  new Response<GetStudent> (response);

        }
        
    private async Task<string> UploadFile(IFormFile file)
    {
        if (file == null) return null;
        
        //create folder if not exists
        var path = Path.Combine( _hostEnvironment.WebRootPath, "std");
        if (Directory.Exists(path) == false) Directory.CreateDirectory(path);
        
        var filepath = Path.Combine(path, file.FileName);
        using (var stream = new FileStream(filepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return file.FileName;
    }

    private async Task<string> UpdateFile(IFormFile file, string oldFileName)
    {
        //delete old image if exists
        var filepath = Path.Combine(_hostEnvironment.WebRootPath, "std", oldFileName);
        if(File.Exists(filepath) == true) File.Delete(filepath);
        
        var newFilepath = Path.Combine(_hostEnvironment.WebRootPath, "std", file.FileName);
        using (var stream = new FileStream(newFilepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return file.FileName;

    }
      public async Task<Response<string>> DeleteStudent(int id)
        {      
        var find = await _context.Students.FindAsync(id);
        _context.Students.Remove(find);
        await _context.SaveChangesAsync();
           if(find.ID > 0 )  return new Response<string>("Student deleted successfully");

        
               return new Response<string>(HttpStatusCode.BadRequest, "Student not found");
        }
}
