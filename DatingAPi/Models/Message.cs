using System;
using System.Collections.Generic;

namespace DatingAPi.Models;

public partial class Message
{
    public int Idmessage { get; set; }

    public int? Idconversation { get; set; }

    public int? Iduser { get; set; }

    public string? Contenu { get; set; }

    public DateTime? Dateenvoi { get; set; }
}
