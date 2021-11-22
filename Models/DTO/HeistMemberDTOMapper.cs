using Oceans11.DataRepository;
using System.Collections.Generic;

namespace Oceans11.Models.DTO
{
  
    public static class HeistMemberDTOMapper
    {
        
        public static HeistMemberDTO MapToDto(HeistMember heistMember)
            {


            return new HeistMemberDTO()
            {

                Id = heistMember.Id,
                Name = heistMember.Name,
                MemberSkills =heistMember.MemberSkills,
            Gender = new GenderDTO()
                {
                    Naziv = heistMember.Gender.Naziv,

                }, MainSkill = new SkillDTO()
                {
                    Naziv = heistMember.MainSkill.Naziv,

                }, Status = new StatusDTO()
                {
                    Naziv = heistMember.MainSkill.Naziv,

                },
            
                };
            }


        };
    }

