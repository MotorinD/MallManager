using System.ComponentModel.DataAnnotations;

namespace MallManager.DAL.Entities
{
    /// <summary>
    /// Базовый класс для сущности соответствующей представлению в БД. Репозитории работают только с классами производными от данного для гарантии наличия поля с первичным ключом
    /// </summary>
    public class BaseEntity
    {
        [KeyAttribute]
        public int Id { get; set; }
    }
}
