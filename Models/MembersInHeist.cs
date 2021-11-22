using System;
using System.Collections.Generic;

#nullable disable

namespace Oceans11.Models
{
    public partial class MembersInHeist
    {
        public int Id { get; set; }
        public int HeistMemberId { get; set; }
        public int HeistId { get; set; }

        public virtual Heist Heist { get; set; }
        public virtual HeistMember HeistMember { get; set; }
    }
}
