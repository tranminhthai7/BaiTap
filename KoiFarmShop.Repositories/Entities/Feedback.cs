﻿using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Feedback
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? Detail { get; set; }
}
