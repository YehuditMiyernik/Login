using System.ComponentModel.DataAnnotations;

namespace Entities;

public class User
{
    public int Id { get; set; }
    [EmailAddress]
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
    [StringLength(8, ErrorMessage = "Name can't be longer then 8.")]
    public string Name { get; set; }
    [StringLength(8, ErrorMessage = "Last name can't be longer then 8.")]
    public string LastName { get; set; }
}