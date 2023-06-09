using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SalesWFPApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        private bool _skipValidation;
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public bool HasErrors => _errors.Count > 0;

        public IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return _errors.Values;
            }

            if (_errors.ContainsKey(propertyName))
            {
                return _errors[propertyName];
            }

            return null;
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void SetError(string propertyName, string error)
        {
            if (!_skipValidation)
            {

                if (!_errors.ContainsKey(propertyName))
                {
                    _errors[propertyName] = new List<string>();
                }

                if (!_errors[propertyName].Contains(error))
                {
                    _errors[propertyName].Add(error);
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                }
            }
        }

        protected void ClearError(string propertyName)
        {
            if (!_skipValidation)
            {
                if (_errors.ContainsKey(propertyName))
                {
                    _errors.Remove(propertyName);
                    ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
                }
            }
        }

        protected void SkipValidation(bool skip)
        {
            _skipValidation = skip;
            if (skip)
            {
                _errors.Clear();
            }
        }
    }
}
