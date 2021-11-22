using System;
using System.Collections.Generic;

#nullable disable

namespace Oceans11.Models
{
    public partial class Status
    {
        public Status()
        {
            HeistMembers = new HashSet<HeistMember>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<HeistMember> HeistMembers { get; set; }
    }
}
