using AutoMapper;
using MallManager.DataModels;
using System.Collections.Generic;

namespace MallManager.Managers
{
    public partial class DataManager
    {
        public List<RoomDataModel> GetRoomDataModelList()
        {
            var entityList = this._entityManager.Room.GetList();
            var res = this._mapper.Map<List<RoomDataModel>>(entityList);

            return res;
        }
    }
}
