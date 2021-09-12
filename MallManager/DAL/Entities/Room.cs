namespace MallManager.DAL.Entities
{
    public class Room : BaseEntity
    {
        public int Type { get; set; }

        public decimal Square { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
