using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

public class ServiceProfileCourse : Profile
{
 public ServiceProfileCourse()
 {
 CreateMap<AddCourse, Course>();
 CreateMap<Course,GetCourse>();

 }
}