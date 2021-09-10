using MallManager.Additional;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MallManager.DataModels
{
    public class RoomDataModel
    {
        public int Id { get; set; }

        public RoomTypeEnum Type { get; set; }

        public decimal Square { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public bool IsRented { get; set; }
    }
}
