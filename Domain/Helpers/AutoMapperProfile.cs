using AutoMapper;
using Data.Entities;
using Domain.Models;

namespace Domain.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // REMOVE MORE AHEAD... THIS IS AN EXAMPLE... 
            CreateMap<Album, AlbumDto>();
            CreateMap<AlbumDto, Album>();

            CreateMap<AlbumPrice, AlbumPriceDto>();
            CreateMap<AlbumPriceDto, AlbumPrice>();

            CreateMap<AlbumRating, AlbumRatingDto>();
            CreateMap<AlbumRatingDto, AlbumRating>();

            CreateMap<Artist, ArtistDto>();
            CreateMap<ArtistDto, Artist>();

            CreateMap<Contacts, ContactsDto>();
            CreateMap<ContactsDto, Contacts>();

            CreateMap<MusicType, MusicTypeDto>();
            CreateMap<MusicTypeDto, MusicType>();

            CreateMap<RatingType, RatingTypeDto>();
            CreateMap<RatingTypeDto, RatingType>();

            CreateMap<Song, SongDto>();
            CreateMap<SongDto, Song>();

            CreateMap<SongPrice, SongPriceDto>();
            CreateMap<SongPriceDto, SongPrice>();


            // ORIGINAL CODE
            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();

            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();

            CreateMap<DepartmentEmployee, DepartmentEmployeeDto>();
            CreateMap<DepartmentEmployeeDto, DepartmentEmployee>();

            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();

            CreateMap<Gender, GenderDto>();
            CreateMap<GenderDto, Gender>();

            CreateMap<Language, LanguageDto>();
            CreateMap<LanguageDto, Language>();

            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();

            CreateMap<SiteStyleType, SiteStyleTypeDto>();
            CreateMap<SiteStyleTypeDto, SiteStyleType>();

            CreateMap<SystemType, SystemTypeDto>();
            CreateMap<SystemTypeDto, SystemType>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<UserRole, UserRoleDto>();
            CreateMap<UserRoleDto, UserRole>();

            CreateMap<VersionHistory, VersionHistoryDto>();
            CreateMap<VersionHistoryDto, VersionHistory>();
        }
    }
}
