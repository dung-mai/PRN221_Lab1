using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public interface IMemberRepository
    {
        public void AddMember(Member member);
        public void UpdateMember(Member member);
        public void DeleteMember(Member member);
        public Member? GetMemberById(int id);
        public List<Member> GetAllMembers();
        public Member? GetMemberByEmail(string? email);
    }
}
