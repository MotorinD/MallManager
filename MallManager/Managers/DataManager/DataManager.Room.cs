using MallManager.DAL;
using MallManager.DAL.Entities;
using MallManager.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace MallManager.Managers
{
    public partial class DataManager
    {
        public List<RoomDataModel> GetRoomDataModelList()
        {
            using (var db = new MallContext())
            {
                var roomList = db.Rooms.ToList();
                var res = this._mapper.Map<List<RoomDataModel>>(roomList);
                return res;
            }
        }

        public void AddRoomDataModel(RoomDataModel roomDataModel)
        {
            using (var db = new MallContext())
            {
                var room = this._mapper.Map<Room>(roomDataModel);
                db.Rooms.Add(room);
                db.SaveChanges();
            }
        }

        public void EditRoomDataModel(RoomDataModel roomDataModel)
        {
            using (var db = new MallContext())
            {
                var targetRoom = db.Rooms.FirstOrDefault(o => o.Id == roomDataModel.Id);
                if (targetRoom is null)
                    return;

                this._mapper.Map(roomDataModel, targetRoom);
                db.SaveChanges();
            }
        }

        public void DeleteRoomDataModel(int id)
        {
            using (var db = new MallContext())
            {
                var room = db.Rooms.FirstOrDefault(o => o.Id == id);
                if (room is null)
                    return;

                db.Rooms.Remove(room);
                db.SaveChanges();
            }
        }
    }
}
