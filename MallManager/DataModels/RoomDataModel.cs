using MallManager.Enums;

namespace MallManager.DataModels
{
    /// <summary>
    /// Помещение: модель данных для работы в системе
    /// </summary>
    public class RoomDataModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public RoomTypeEnum Type { get; set; }

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
    }
}
