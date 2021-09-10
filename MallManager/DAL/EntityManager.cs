namespace MallManager.DAL
{
    public class EntityManager
    {
        public static EntityManager Active { get; set; }

        public static void InitEntityManager()
        {
            Active = new EntityManager
            {
                Room = new RoomRepository()
            };
        }

        public RoomRepository Room { get; set; }
    }
}
