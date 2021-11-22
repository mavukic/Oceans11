using System.Collections.Generic;

namespace Oceans11.Models.DTO
{
    public class HeistMemberDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
      

        public virtual GenderDTO Gender { get; set; }
        public virtual SkillDTO MainSkill { get; set; }
        public virtual StatusDTO Status { get; set; }

        public virtual ICollection<MemberSkill> MemberSkills { get; set; }

    }
}
