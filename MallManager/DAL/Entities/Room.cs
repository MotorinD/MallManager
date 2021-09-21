namespace MallManager.DAL.Entities
{
    /// <summary>
    /// Помещение: сущность соответсвующая представлению в БД
    /// </summary>
    public class Room : BaseEntity
    {
        /// <summary>
        /// Тип
        /// </summary>
        public int Type { get; set; }

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
    }
}
