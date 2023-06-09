using AutoMapper;
using BusinessLayer.BusinessObject;
using BusinessLayer.Validator;
using DataAccess;
using DataAccess.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public void AddMember(MemberObject memberBO)
        {
            var member = _mapper.Map<Member>(memberBO);
            _memberRepository.AddMember(member);
        }

        public void DeleteMember(MemberObject memberBO)
        {
            var member = _mapper.Map<Member>(memberBO);
            _memberRepository.DeleteMember(member);
        }

        public List<MemberObject> GetAllMembers()
        {
            return _memberRepository.GetAllMembers().Select(p => _mapper.Map<MemberObject>(p)).ToList();
        }

        public MemberObject? GetMemberById(int id)
        {
            return _mapper.Map<MemberObject>(_memberRepository.GetMemberById(id));
        }

        public void UpdateMember(MemberObject memberBO)
        {
            var member = _mapper.Map<Member>(memberBO);
            _memberRepository.UpdateMember(member);
        }

        public ValidationObject Login(string email, string password)
        {
            Member? member = _memberRepository.GetMemberByEmail(email);
            if(member == null)
            {
                return new ValidationObject(false, "Account not exists!");
            } else
            {
                if (!member.Password.Equals(password))
                {
                    return new ValidationObject(false, "Please check your password!");
                } else
                {
                    return new ValidationObject(true, "Login successfully!");
                }
            }
        }
    }
}
