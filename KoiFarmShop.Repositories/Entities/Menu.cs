﻿using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public partial class Menu
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Link { get; set; }

    public string? Target { get; set; }

    public string? Description { get; set; }

    public bool? Status { get; set; }

    public int Position { get; set; }
}
