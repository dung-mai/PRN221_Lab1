using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly PRN221_SalesApplicationContext _context;

        public MemberRepository(PRN221_SalesApplicationContext context)
        {
            _context = context;
        }

        public void AddMember(Member member)
        {
            if (member != null)
            {
                _context.Members.Add(member);
                _context.SaveChanges();
            }
        }

        public void UpdateMember(Member member)
        {
            if (member != null)
            {
                _context.Members.Update(member);
                _context.SaveChanges();
            }
        }

        public void DeleteMember(Member member)
        {
            if (member != null)
            {
                _context.Members.Remove(member);
                _context.SaveChanges();
            }
        }

        public List<Member> GetAllMembers()
        {
            return _context.Members.ToList();
        }

        public Member? GetMemberById(int id)
        {
            return _context.Members.FirstOrDefault(m => m.MemberId == id);
        }
    }
}
