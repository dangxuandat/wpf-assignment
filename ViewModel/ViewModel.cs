using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Assignment_Version2.ViewModel
{
    public class ViewModel : INotifyDataErrorInfo,INotifyPropertyChanged
    {
        protected Dictionary<string, List<string>> _errorsOnProperty = new Dictionary<string, List<string>>(); //contains all errors of specific property
        public bool HasErrors
        {
            get
            {
                try
                {
                    List<string> errors = _errorsOnProperty.Values.FirstOrDefault(error => error.Count > 0);
                    if (errors != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch
                {
                    return true;
                }
            }
        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        //Caller Member Name will return name of method
        protected void OnPropertyChanged([CallerMemberName] string parameter = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(parameter));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if(propertyName != null)
            {
                _errorsOnProperty.TryGetValue(propertyName, out List<string> errors);
                return errors;
            }
            else
            {
                return null;
            }
        }

        protected void AddErrorOfPropertyInErrorsList(string property, string message)
        {
            if (!_errorsOnProperty.ContainsKey(property))
            {
                _errorsOnProperty.Add(property, new List<string>());
            }// end if property does not exist in errors list
            _errorsOnProperty[property].Add(message);
            OnErrorChanged(property);
        }

        protected void ClearErrorsOfProperty(string property)
        {
            if (_errorsOnProperty.ContainsKey(property))
            {
                _errorsOnProperty.Remove(property);
                OnErrorChanged(property);
            }//Delete All Errors of that property before check to prevent duplicating error 
        }
        private void OnErrorChanged(string property)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(property));
        }
    }
}
