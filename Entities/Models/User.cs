using System;
using System.Collections.Generic;

namespace Entities.Models;

public partial class User
{
    public int Id { get; set; }

    public string UserName { get; set; } = null!;

    public int Password { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
