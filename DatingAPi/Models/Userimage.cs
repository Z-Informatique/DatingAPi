using System;
using System.Collections.Generic;

namespace DatingAPi.Models;

public partial class Userimage
{
    public int IduserImage { get; set; }

    public int? Iduser { get; set; }

    public string? Filename { get; set; }
}
