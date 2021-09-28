using MallManager.DataModels;

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
        public RoomDataModel DataModel { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        public string Square { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// True если арендовано, False если свободно
        /// </summary>
        public bool IsRented { get; set; }
    }
}
