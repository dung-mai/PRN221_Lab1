using BusinessLayer.BusinessObject;
using BusinessLayer.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWFPApp.ViewModel
{
    public class MemberViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        private readonly IMemberService _memberService;

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
        private bool isCommandExecuted;
        public bool IsCommandExecuted
        {
            get => isCommandExecuted;
            set
            {
                isCommandExecuted = value;
                OnPropertyChanged(nameof(IsCommandExecuted));
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
            LoadAllMembers();
            DefineRelayCommand();
            IsCommandExecuted = false;
        }


        private void DefineRelayCommand()
        {
            AddMemberCommand = new RelayCommand<MemberObject>(
                p =>
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
                    LoadAllMembers();
                    OnPropertyChanged(nameof(Members));
                    IsCommandExecuted = true;
                },
                p => true);
            UpdateMemberCommand = new RelayCommand<MemberObject>(
                p =>
                {
                    CurMember.Email = Email;
                    CurMember.City = City;
                    CurMember.Password = Password;
                    CurMember.Country = Country;
                    CurMember.CompanyName = CompanyName;

                    //update in db
                    _memberService.UpdateMember(CurMember);

                    //update for Members List in L
                    LoadAllMembers();
                    OnPropertyChanged(nameof(Members));
                    IsCommandExecuted = true;
                },
                p => true);
            DeleteMemberCommand = new RelayCommand<MemberObject>(
                p =>
                {
                    _memberService.DeleteMember(CurMember);
                    Members.Remove(CurMember);
                },
                p => true);

            ResetCommand = new RelayCommand(() =>
            {
                MemberId = 0;
                Email = "";
                City = "";
                Password = "";
                CompanyName = "";
                Country = "";

                IsCommandExecuted = false;
            });
        }

        private void LoadAllMembers()
        {
            Members = new ObservableCollection<MemberObject>(_memberService.GetAllMembers());
        }


        public string this[string columnName]
        {
            get
            {
                string error = null;
                switch (columnName)
                {
                    case nameof(Email):
                        if (string.IsNullOrEmpty(Email))
                        {
                            error = "Email is required.";
                        }
                        break;
                    case nameof(Password):
                        if (string.IsNullOrEmpty(Email))
                        {
                            error = "Email is required.";
                        }
                        break;
                    case nameof(Country):
                        if (string.IsNullOrEmpty(Country))
                        {
                            error = "Country is required.";
                        }
                        break;
                    case nameof(CompanyName):
                        if (string.IsNullOrEmpty(CompanyName))
                        {
                            error = "CompanyName is required.";
                        }
                        break;
                    case nameof(City):
                        if (string.IsNullOrEmpty(City))
                        {
                            error = "City is required.";
                        }
                        break;
                }
                return error;
            }
        }

        public string Error => null;
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
