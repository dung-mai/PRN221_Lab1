using BusinessLayer.Services;
using BusinessLayer.Validator;
using CommunityToolkit.Mvvm.Input;
using SalesWFPApp.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SalesWFPApp.ViewModel
{
    public class LoginViewModel
    {
        private readonly IMemberService _memberService;
        public string Email { get; set; }
        public string Password { get; set; }

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }

        public LoginViewModel(IMemberService memberService)
        {
            _memberService = memberService;
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            ValidationObject validation = _memberService.Login(Email, Password);
            MessageBox.Show(validation.Message);
            if (validation.IsValid)
            {
                var memberWindow = new MemberWindow();
                memberWindow.Show();
                Application.Current.MainWindow.Close();
            }
        }
    }
}
