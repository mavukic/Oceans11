using System;
using System.Collections.Generic;

#nullable disable

namespace Oceans11.Models
{
    public partial class MemberSkill
    {
        public int HeistMemberId { get; set; }
        public int SkillId { get; set; }
        public string Level { get; set; }

        public virtual HeistMember HeistMember { get; set; }
        public virtual Skill Skill { get; set; }
    }
}
