using AutoMapper;
using Serve.Core.Models;
using Serve.Domain.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serve.Infrastructure.LogicImplementation
{
    public class MappingProfile : Profile
    {
        //n.b ==> c = Dto, x = model
        public MappingProfile()
        {
            CreateMap<Appointment, AppointmentDto>();
            
            CreateMap<AppointmentForCreationDto, Appointment>();

            CreateMap<AppointmentForUpdateDto, Appointment>();

            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerForUpdateDto, Customer>();


            //.ForMember(c => c.Address,
            //opt => opt.MapFrom(x => string.Join(' ', x.Address, x.State)));
            
            //CreateMap<Customer, CustomerDto>();.ReverseMap();
        }
    }
}
