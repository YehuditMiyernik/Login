using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CategoryDTO
    {
        public string CategoryName { get; set; } = null!;
        [Required]
        public string Id { get; set; } = null!;
    }
}
