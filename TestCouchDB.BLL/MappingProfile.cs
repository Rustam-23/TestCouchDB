using AutoMapper;
using TestCouchDB.BLL.Models;
using TestCouchDB.DAL.Entities;

namespace TestCouchDB.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();
            CreateMap<RecordEntity, UserModel>().ReverseMap();
        }
    }
}