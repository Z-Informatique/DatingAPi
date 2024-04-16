using System;
using System.Collections.Generic;

namespace DatingAPi.Models;

public partial class Userabonnement
{
    public int IduserAbonnement { get; set; }

    public int? IdAbonnement { get; set; }

    public int? Iduser { get; set; }

    public DateTime? Datedebut { get; set; }

    public DateTime? Datefin { get; set; }

    public DateTime? Createdat { get; set; }
}
