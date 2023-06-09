using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using DataAccess.Models;
using FluentValidation;
using SalesWFPApp.HelperObject;
using SalesWFPApp.Validator;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace SalesWFPApp.ViewModel
{
    public class MemberViewModel : BaseViewModel
    {
        private readonly IMemberService _memberService;
        private MemberViewModelValidator validator;

        private int _memberId;
        public int MemberId
        {
            get { return _memberId; }
            set
            {
                _memberId = value;
                OnPropertyChanged(nameof(MemberId));
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                ValidateProperty(nameof(Email), value);
                OnPropertyChanged(nameof(Email));
            }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                ValidateProperty(nameof(City), value);
                OnPropertyChanged(nameof(City));
            }
        }
        private string _country;
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                ValidateProperty(nameof(Country), value);
                OnPropertyChanged(nameof(Country));
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                ValidateProperty(nameof(Password), value);
                OnPropertyChanged(nameof(Password));
            }
        }
        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                _companyName = value;
                ValidateProperty(nameof(CompanyName), value);
                OnPropertyChanged(nameof(CompanyName));
            }
        }
        private MemberObject _curMember;
        public MemberObject CurMember
        {
            get { return _curMember; }
            set
            {
                _curMember = value;
                if (value != null)
                {
                    MemberId = value.MemberId;
                    Email = value.Email;
                    City = value.City;
                    Password = value.Password;
                    CompanyName = value.CompanyName;
                    Country = value.Country;
                    Password = value.Password;
                }
                OnPropertyChanged(nameof(CurMember));
            }
        }

        public ObservableCollection<MemberObject> Members { get; set; }

        public RelayCommand<MemberObject> DeleteMemberCommand { get; set; }
        public RelayCommand<MemberObject> AddMemberCommand { get; set; }
        public RelayCommand<MemberObject> UpdateMemberCommand { get; set; }
        public RelayCommand ResetCommand { get; set; }

        public MemberViewModel(IMemberService memberService)
        {
            _memberService = memberService;
            validator = new MemberViewModelValidator();
            LoadAllMembers();
            DefineRelayCommand();
        }

        private void DefineRelayCommand()
        {
            AddMemberCommand = new RelayCommand<MemberObject>(AddNewMember, m => true);
            UpdateMemberCommand = new RelayCommand<MemberObject>(UpdateMember, m => true);
            DeleteMemberCommand = new RelayCommand<MemberObject>(DeleteMember, m => true);
            ResetCommand = new RelayCommand(ResetTextbox);
        }

        private void DeleteMember(MemberObject? member)
        {
            _memberService.DeleteMember(CurMember);
            NotificationObject.DisplayMessage("Delete successfully!");

            Members.Remove(CurMember);
            ResetTextbox();
        }

        private async void UpdateMember(MemberObject? member)
        {
            var result = await validator.ValidateAsync(this);
            if (result.IsValid)
            {
                CurMember.Email = Email;
                CurMember.City = City;
                CurMember.Password = Password;
                CurMember.Country = Country;
                CurMember.CompanyName = CompanyName;

                //update in db
                _memberService.UpdateMember(CurMember);
                NotificationObject.DisplayMessage("Update successfully!");

                //update UI
                LoadAllMembers();
                OnPropertyChanged(nameof(Members));
                ResetTextbox();
            }
            else
            {
                NotificationObject.DisplayMessage("Please enter again!");
            }
        }

        private async void AddNewMember(MemberObject? m)
        {
            var result = await validator.ValidateAsync(this);
            if (result.IsValid)
            {
                ///logic
                MemberObject member = new MemberObject
                {
                    MemberId = _memberId,
                    Email = _email,
                    City = _city,
                    Password = _password,
                    CompanyName = _companyName,
                    Country = _country
                };
                _memberService.AddMember(member);
                NotificationObject.DisplayMessage("Added successfully!");

                //UDPATE UI
                LoadAllMembers();
                OnPropertyChanged(nameof(Members));
                ResetTextbox();
            }
            else
            {
                NotificationObject.DisplayMessage("Please enter again!");
            }
        }

        private void ResetTextbox()
        {
            SkipValidation(true);
            MemberId = 0;
            Email = "";
            City = "";
            Password = "";
            CompanyName = "";
            Country = "";
            SkipValidation(false);
        }

        private void LoadAllMembers()
        {
            Members = new ObservableCollection<MemberObject>(_memberService.GetAllMembers());
        }

        private async void ValidateProperty(string propertyName, object value)
        {
            var result = await validator.ValidateAsync(this);
            var errors = result.Errors.Where(e => e.PropertyName == propertyName).ToList();
            if (errors.Any())
            {
                var errorMsg = string.Join(Environment.NewLine, errors.Select(e => e.ErrorMessage));
                SetError(propertyName, errorMsg);
            }
            else
            {
                ClearError(propertyName);
            }
        }
    }
}
