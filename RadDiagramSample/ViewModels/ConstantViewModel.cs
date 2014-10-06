using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using RadDiagramSample.Views;

namespace RadDiagramSample.ViewModels
{
    public class ConstantViewModel:ControlViewModel
    {
        private string _value;
        public string Value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnPropertyChanged("Value");
                }
            }
        }

        public ConstantViewModel()
        {
            Value = "Not Set";
        }
    }
}
