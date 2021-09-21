using System.ComponentModel;

namespace MallManager.Enums
{
    /// <summary>
    /// Типы помещений
    /// </summary>
    public enum RoomTypeEnum
    {
        /// <summary>
        /// Магазин
        /// </summary>
        [Description("Магазин")]
        Shop = 0,

        /// <summary>
        /// Киоск
        /// </summary>
        [Description("Киоск")]
        Stand = 1,

        /// <summary>
        /// Супермаркет
        /// </summary>
        [Description("Супермаркет")]
        Supermarket = 2,

        /// <summary>
        /// ПСЗ(Помещение Свободного Назначения)
        /// </summary>
        [Description("ПСЗ(Помещение Свободного Назначения)")]
        Space = 3
    }
}
