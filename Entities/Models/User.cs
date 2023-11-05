using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models;

public partial class User
{
    public int Id { get; set; }

    [EmailAddress]
    [Required]
    public string UserName { get; set; } = null!;

    [Required]
    public string Password { get; set; } = null!;

    [Required]
    [StringLength(8, ErrorMessage = "Name can't be longer then 8.")]
    public string Name { get; set; } = null!;

    [StringLength(8, ErrorMessage = "Last name can't be longer then 8.")]
    public string LastName { get; set; } = null!;
}
