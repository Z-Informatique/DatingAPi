using System;
using System.Collections.Generic;

namespace DatingAPi.Models;

public partial class Ville
{
    public int Idville { get; set; }

    public string? Nom { get; set; }

    public int? Idpays { get; set; }
}
