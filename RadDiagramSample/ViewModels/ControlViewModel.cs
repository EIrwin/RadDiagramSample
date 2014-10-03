using System;
using System.Windows;
using System.Windows.Controls;
using RadDiagramSample.Views;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace RadDiagramSample.ViewModels
{
    public class ControlViewModel:NodeViewModelBase
    {
        private DateTime _timestamp;
        private string _name;

        public DateTime Timestamp
        {
            get { return _timestamp; }
            set
            {
                if(_timestamp != value)
                {
                    _timestamp = value;
                    OnPropertyChanged("Timestamp");
                }
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public UIElement ControlView { get; private set; }

        public ControlViewModel()
        {
            Timestamp = DateTime.Now;

            ControlView = new ControlAView() {DataContext = this};
        }
    }
}