using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Furniture.BLL;
using Furniture.DAL;
namespace Furniture.PL
{
    /// <summary>
    /// AutoMapper
    /// </summary>
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Регистрация AutoMapper
        /// </summary>
        public static void RegisterMaps()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<Stuff, StuffDTO>().ForMember(t => t.Room, t => t.MapFrom(d => d.Room.Name));
                cfg.CreateMap<FurnitureList, FurnitureListDTO>(MemberList.None);
                cfg.CreateMap<FurnitureListDTO, FurnitureListViewModel>(MemberList.None);
                cfg.CreateMap<FurnitureListDTO, FurnitureList>(MemberList.None);
                cfg.CreateMap<FurnitureListViewModel, FurnitureListDTO>(MemberList.None);
               

            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
