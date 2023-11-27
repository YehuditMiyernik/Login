using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }

        [EmailAddress]
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [StringLength(20, ErrorMessage = "Name can't be longer then 20.")]
        public string Name { get; set; } = null!;
        [StringLength(20, ErrorMessage = "Last Name can't be longer then 20.")]
        public string LastName { get; set; } = null!;
    }
}
