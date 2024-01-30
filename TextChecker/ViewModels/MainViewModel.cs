using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using TextChecker.CommandsBase;
using TextChecker.Core;
using TextChecker.MVVM;
using TextChecker.Services;

namespace TextChecker.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ITextCheckerService _textCheckerService;

        private string _text;
        private string _value;
        private string _condition;
        private bool _caseSensitive;
        private bool _result;

        public string Text
        {
            get { return _text; }
            set 
            {
                ValidateStringProperty(value);
                SetProperty(ref _text, value); 
            }
        }

        public string Value
        {
            get { return _value; }
            set 
            {
                ValidateStringProperty(value);
                SetProperty(ref this._value, value); 
            }
        }

        public string Condition
        {
            get { return _condition; }
            set { SetProperty(ref _condition, value); }
        }

        public bool CaseSensitive
        {
            get { return _caseSensitive; }
            set { SetProperty(ref _caseSensitive, value); }
        }

        public bool Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        public ICommand CheckConditionCommand { get; }

        public ObservableCollection<string> Conditions { get; } = new ObservableCollection<string>
        {
            ConditionEnum.IsEqual.ToString(),
            ConditionEnum.StartsWith.ToString(),
            ConditionEnum.EndsWith.ToString(),
            ConditionEnum.Contains.ToString()
        };

        public MainViewModel()
        {
            _textCheckerService = new TextCheckerService();

            Text = "The quick red fox jump over the lazy dog";
            Value = "the";
            CaseSensitive = false;
            Condition = Conditions[1];

            CheckConditionCommand = new RelayCommand<object>(CheckCondition, CanCheckCondition);
        }

        private bool CanCheckCondition(object obj)
        {
            return !string.IsNullOrEmpty(Text) && !string.IsNullOrEmpty(Value);
        }

        private void CheckCondition(object obj)
        {
            Enum.TryParse(Condition, out ConditionEnum condition);
            Result = _textCheckerService.CheckText(Text, Value, CaseSensitive, condition);
        }
    }
}
