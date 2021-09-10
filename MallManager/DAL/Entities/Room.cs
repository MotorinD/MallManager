using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallManager.DAL.Entities
{
    public class Room
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public decimal Square { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
