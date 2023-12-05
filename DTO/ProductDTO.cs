using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public int Id { get; set; }

        public string ProdName { get; set; } = null!;

        public int Price { get; set; }

        public string ProdImage { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string CategoryName { get; set; } = null!;

    }
}
