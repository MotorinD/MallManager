using System.ComponentModel;

namespace MallManager.Enums
{
    /// <summary>
    /// Типы помещений
    /// </summary>
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum RoomTypeEnum
    {
        /// <summary>
        /// Магазин
        /// </summary>
        [LocalizedDescription("RoomTypeEnumShop", typeof(MainResourses))]
        Shop = 0,

        /// <summary>
        /// Киоск
        /// </summary>
        [LocalizedDescription("RoomTypeEnumStand", typeof(MainResourses))]
        Stand = 1,

        /// <summary>
        /// Супермаркет
        /// </summary>
        [LocalizedDescription("RoomTypeEnumSupermarket", typeof(MainResourses))]
        Supermarket = 2,

        /// <summary>
        /// ПСЗ(Помещение Свободного Назначения)
        /// </summary>
        [LocalizedDescription("RoomTypeEnumSpace", typeof(MainResourses))]
        Space = 3
    }
}
