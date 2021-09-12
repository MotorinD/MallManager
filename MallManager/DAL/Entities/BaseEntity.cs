using System.ComponentModel.DataAnnotations;

namespace MallManager.DAL.Entities
{
    public class BaseEntity
    {
        [KeyAttribute]
        public int Id { get; set; }
    }
}
