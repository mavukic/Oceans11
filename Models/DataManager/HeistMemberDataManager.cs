using Microsoft.EntityFrameworkCore;
using Oceans11.DataRepository;
using Oceans11.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Oceans11.Models.DataManager
{
    public class HeistMemberDataManager:IDataRepository<HeistMember, HeistMemberDTO>
    {
        readonly MoneyHeistDBContext _context;

    public HeistMemberDataManager(MoneyHeistDBContext context)
    {
        _context = context;
    }

    public  void Add(HeistMember entity)
    {
        _context.HeistMembers.Add(entity);
        _context.SaveChanges();

    }

        void IDataRepository<HeistMember, HeistMemberDTO>.Delete(HeistMember entity)
        {
            throw new System.NotImplementedException();
        }

        HeistMember IDataRepository<HeistMember, HeistMemberDTO>.Get(long id)
    {
        var heistMember = _context.HeistMembers
            .SingleOrDefault(b => b.Id == id);

        return heistMember;
    }

        IEnumerable<HeistMember> IDataRepository<HeistMember, HeistMemberDTO>.GetAll()
        {

            return _context.HeistMembers.Include(p=>p.MemberSkills).ToList();
        }

        HeistMemberDTO IDataRepository<HeistMember, HeistMemberDTO>.GetDto(long id)
    {
        _context.ChangeTracker.LazyLoadingEnabled = true;

        using (var context = new MoneyHeistDBContext())
        {
            var heistMember = context.HeistMembers
                .SingleOrDefault(b => b.Id == id);

            return HeistMemberDTOMapper.MapToDto(heistMember);
        }
    }

       

        void IDataRepository<HeistMember, HeistMemberDTO>.Update(HeistMember entityToUpdate, HeistMember entity)
        {
            throw new System.NotImplementedException();
        }
    }
}