using MallManager.Additional;
using MallManager.DAL.Entities;

namespace MallManager.ViewModels
{
    public class RoomViewModel
    {
        public Room DataModel { get; set; }

        public string Type { get; set; }

        public decimal Square { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsRented { get; set; }

        public RoomViewModel(Room dataModel)
        {
            this.DataModel = dataModel;
            this.Type = ((RoomTypeEnum)dataModel.Type).GetDescription();
            this.Square = dataModel.Square;
            this.Price = dataModel.Price;
            this.Description = dataModel.Description;
        }
    }
}
