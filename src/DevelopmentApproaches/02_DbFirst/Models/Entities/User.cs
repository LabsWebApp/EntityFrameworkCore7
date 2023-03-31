using System;
using System.Collections.Generic;

namespace DbFirst.Models.Entities;

public class User
{
    public Guid Id { get; init; }

    public string? Name { get; set; }

    public long Age { get; set; }
}
