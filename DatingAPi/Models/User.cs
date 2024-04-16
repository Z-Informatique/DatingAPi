using System;
using System.Collections.Generic;

namespace DatingAPi.Models;

public partial class User
{
    public int Idusers { get; set; }

    public string? Telephone { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Token { get; set; }

    public int? CodeSms { get; set; }

    public DateTime? Createdat { get; set; }

    public string? RefreshToken { get; set; }

    public DateTime? Datenaissance { get; set; }

    public int? Idquartier { get; set; }
    public bool IsConnected { get; set; }
    public bool IsMember { get; set; }
    public ICollection<Userabonnement> Userabonnements { get; } = new List<Userabonnement>();
}
