using AutoMapper;
using MallManager.DAL.Entities;
using MallManager.DataModels;
using MallManager.Enums;
using MallManager.ViewModels;
using MallManager.Additional;
using System.Threading;
using System.Globalization;

namespace MallManager
{
    public class MapperConfiguration
    {
        private static CultureInfo _currentCulture => Thread.CurrentThread.CurrentUICulture;
        public static IConfigurationProvider GetConfiguration()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Room, RoomDataModel>()
                    .ForMember(nameof(RoomDataModel.Type), o => o.MapFrom(src => (RoomTypeEnum)src.Type));

                cfg.CreateMap<RoomDataModel, Room>()
                    .ForMember(nameof(Room.Type), o => o.MapFrom(src => (int)src.Type));

                cfg.CreateMap<RoomDataModel, RoomViewModel>()
                    .ForMember(nameof(RoomViewModel.DataModel), o => o.MapFrom(src => src))
                    .ForMember(nameof(RoomViewModel.Type), o => o.MapFrom(src => src.Type.GetDescription()))
                    .ForMember(nameof(RoomViewModel.Square), o => o.MapFrom(src => src.Square.ToString("F", _currentCulture)))
                    .ForMember(nameof(RoomViewModel.Price), o => o.MapFrom(src => src.Price.ToString("C2", _currentCulture)));
            });

            return config;
        }
    }
}
