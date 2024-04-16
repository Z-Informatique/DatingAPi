using System;
using System.Collections.Generic;

namespace DatingAPi.Models;

public partial class Quartier
{
    public int Idquartier { get; set; }

    public string? Nom { get; set; }

    public int? Idville { get; set; }
}
