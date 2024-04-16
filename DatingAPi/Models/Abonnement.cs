using System;
using System.Collections.Generic;

namespace DatingAPi.Models;

public partial class Abonnement
{
    public int Idabonnement { get; set; }

    public string? Nom { get; set; }

    public string? Duree { get; set; }

    public decimal? Prix { get; set; }

    public string? Devise { get; set; }

    public string? Details { get; set; }

    public sbyte? IsPopulaire { get; set; }
}
