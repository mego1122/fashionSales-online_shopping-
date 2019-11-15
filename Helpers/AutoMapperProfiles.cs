using System.Linq;
using AutoMapper;
using FashionSales.Dtos;
using FashionSales.Models;

namespace FashionSales.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.PhotoUrl);
                }).ForMember(dest => dest.PhoneNumber, opt => {
                    opt.MapFrom(src => src.PhoneNumber);
                }).ForMember(dest => dest.UserName, opt => {
                    opt.MapFrom(src => src.UserName);
                });

            

        //            public string Username { get; set; }
            //public string PhoneNumber { get; set; }
            //public string PhotoUrl { get; set; }
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt => {
                    opt.MapFrom(src => src.PhotoUrl);
                });
            CreateMap<UserForUpdateDto, User>();
            CreateMap<UserForRegisterDto, User>();
          
        }

       
}
}