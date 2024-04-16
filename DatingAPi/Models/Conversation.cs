using System;
using System.Collections.Generic;

namespace DatingAPi.Models;

public partial class Conversation
{
    public int Idconversation { get; set; }

    public string? NomConversation { get; set; }

    //public ICollection<Userconversation> Userconversations { get; set; }
    //public ICollection<User> Users { get; set; }
}
