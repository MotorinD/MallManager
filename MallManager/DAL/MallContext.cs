using MallManager.DAL.Entities;
using System.Data.Entity;

namespace MallManager.DAL
{
    public class MallContext : DbContext
    {
        public MallContext() : base("DBConnection") { }

        public DbSet<Room> Rooms { get; set; }
    }
}
