using MallManager.DAL;
using MallManager.DAL.Entities;
using MallManager.Interfaces;

namespace MallManager.Managers
{
    public class EntityManager
    {
        public EntityManager()
        {
            this.Room = new SqlRepository<Room>();
        }

        public IBaseRepository<Room> Room { get; set; }
    }
}
