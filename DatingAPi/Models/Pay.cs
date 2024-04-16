using System;
using System.Collections.Generic;

namespace DatingAPi.Models;

public partial class Pay
{
    public int Idpays { get; set; }

    public string? Code { get; set; }

    public string? Indicatif { get; set; }

    public string? Nom { get; set; }
}
