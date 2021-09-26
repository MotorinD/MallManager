using MallManager.DAL;
using MallManager.DAL.Entities;
using MallManager.Interfaces;

namespace MallManager.Managers
{
    /// <summary>
    /// Менеджер доступа к сущностям соответствующих представлению в БД
    /// </summary>
    public class EntityManager
    {
        public EntityManager()
        {
            this.Room = new SqlRepository<Room>();
        }

        public IBaseRepository<Room> Room { get; private set; }
    }
}
