using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

public class ServiceProfile : Profile
{
 public ServiceProfile()
 {
 CreateMap<AddStudent, Student>();
 CreateMap<Student,GetStudent>();

 }
}