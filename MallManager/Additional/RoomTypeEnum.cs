using System.ComponentModel;

namespace MallManager.Additional
{
    public enum RoomTypeEnum
    {
        [Description("Магазин")]
        Shop = 0,

        [Description("Киоск")]
        Stand = 1,

        [Description("Супермаркет")]
        Supermarket = 2, 
        
        [Description("ПСЗ(Помещение Свободного Назначения)")]
        Space = 3
    }
}
