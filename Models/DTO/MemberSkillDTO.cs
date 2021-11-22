namespace Oceans11.Models.DTO
{
    public class MemberSkillDTO
    {
        public string Level { get; set; }

        public virtual HeistMemberDTO HeistMember { get; set; }
        public virtual SkillDTO Skill { get; set; }
    }
}
