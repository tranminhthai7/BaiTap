﻿using System;
using System.Collections.Generic;

namespace KoiFarmShop.Repositories.Entities;

public class Contact
{
    public int Id { get; set; }

    public string? Name { get; set; }
    public string? Email { get; set; }
	public string? Phone { get; set; }
	public string? Detail { get; set; }

    public bool? Status { get; set; }
}
