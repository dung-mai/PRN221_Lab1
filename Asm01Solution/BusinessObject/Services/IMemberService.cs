using BusinessLayer.BusinessObject;
using BusinessLayer.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IMemberService
    {
        public void AddMember(MemberObject memberBO);
        public void UpdateMember(MemberObject memberBO);
        public void DeleteMember(MemberObject memberBO);
        public MemberObject? GetMemberById(int id);
        public List<MemberObject> GetAllMembers();
        public ValidationObject Login(string username, string password);
    }
}
