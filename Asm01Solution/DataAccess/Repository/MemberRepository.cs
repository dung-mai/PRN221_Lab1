using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
            try
            {
                if (member != null)
                {
                    _context.Members.Add(new Member
                    {
                        City = member.City,
                        Country = member.Country,
                        CompanyName = member.CompanyName,
                        Email = member.Email,
                        Password = member.Password
                    });
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMember(Member member)
        {
            try
            {
                if (member != null)
                {
                    Member? m = GetMemberById(member.MemberId);
                    if (m != null)
                    {
                        m.City = member.City;
                        m.Country = member.Country;
                        m.CompanyName = member.CompanyName;
                        m.Email = member.Email;
                        m.Password = member.Password;
                        _context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteMember(Member member)
        {
            try
            {
                if (member != null)
                {
                    Member? m = GetMemberById(member.MemberId);
                    if(m != null)
                    {
                        _context.Members.Remove(m);
                    }
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

        public Member? GetMemberByEmail(string? email)
        {
            return _context.Members.FirstOrDefault(m => m.Email.Equals(email));
        }
    }
}
