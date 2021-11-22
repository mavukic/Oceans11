//using Oceans11.DataRepository;
//using System.Collections.Generic;

//namespace Oceans11.Models.DTO
//{
//    public class MemberSkillsDTOMapper
//    {
  
       
//        public static MemberSkillDTO MapToDtO(ICollection<MemberSkill> heistMember)
//        {
//            return new MemberSkillDTO()
//            {

//                Level=heistMember.GetEnumerator
//                Name = heistMember.Name,
//                MemberSkills = MemberSkillsDTOMapper.MapToDtO(heistMember.MemberSkills),
//                Gender = new GenderDTO()
//                {
//                    Naziv = heistMember.Gender.Naziv,

//                },
//                MainSkill = new SkillDTO()
//                {
//                    Naziv = heistMember.MainSkill.Naziv,

//                },
//                Status = new StatusDTO()
//                {
//                    Naziv = heistMember.MainSkill.Naziv,

//                },

//            };
//        }


//    };
//}
