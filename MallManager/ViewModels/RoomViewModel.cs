using MallManager.Enums;
using MallManager.DAL.Entities;
using MallManager.Additional;
using System.ComponentModel;

namespace MallManager.ViewModels
{
    /// <summary>
    /// Помещение: модель для отображения в интерфейсе пользователя
    /// </summary>
    public class RoomViewModel
    {
        /// <summary>
        /// Соответвующая модель данных
        /// </summary>
        public Room DataModel { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        public decimal Square { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// True если арендовано, False если свободно
        /// </summary>
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
