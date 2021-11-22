using System;
using System.Collections.Generic;

#nullable disable

namespace Oceans11.Models
{
    public partial class Skill
    {
        public Skill()
        {
            HeistMembers = new HashSet<HeistMember>();
            MemberSkills = new HashSet<MemberSkill>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<HeistMember> HeistMembers { get; set; }
        public virtual ICollection<MemberSkill> MemberSkills { get; set; }
    }
}
