using System;
using System.Collections.Generic;

#nullable disable

namespace Oceans11.Models
{
    public partial class HeistMember
    {
        public HeistMember()
        {
            MemberSkills = new HashSet<MemberSkill>();
            MembersInHeists = new HashSet<MembersInHeist>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? GenderId { get; set; }
        public string Email { get; set; }
        public int? MainSkillId { get; set; }
        public int? StatusId { get; set; }

        public virtual Gender Gender { get; set; }
        public virtual Skill MainSkill { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<MemberSkill> MemberSkills { get; set; }
        public virtual ICollection<MembersInHeist> MembersInHeists { get; set; }
    }
}
