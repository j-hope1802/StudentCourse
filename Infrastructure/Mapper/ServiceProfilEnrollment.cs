using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

public class ServiceProfileEnrollment : Profile
{
 public ServiceProfileEnrollment()
 {
 CreateMap<AddEnrollment, Enrollment>();
 CreateMap<Enrollment,GetEnrollment>();

 }
}