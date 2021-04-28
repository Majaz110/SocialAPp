using System.Linq;
using API.DTOs;
using API.Entities;
using API.Extensions;
using AutoMapper;

namespace Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>().ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain == 1).Url))
            .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Photo, PhotoDto>();
            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Message, MessageDto>()
                .ForMember(dest => dest.SenderPhotoUrl, 
                opt => opt.MapFrom(sourceMember=> sourceMember.Sender.Photos.FirstOrDefault(x => x.IsMain == 1).Url))
                .ForMember(dest => dest.RecipientPhotoUrl, 
                opt => opt.MapFrom(sourceMember=> sourceMember.Recipient.Photos.FirstOrDefault(x => x.IsMain == 1).Url));

        }
    }
}