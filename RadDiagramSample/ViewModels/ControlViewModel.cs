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

        public Guid ID { get; set; }

        public ControlViewModel()
        {
            Timestamp = DateTime.Now;

            ID = Guid.NewGuid();
        }
    }
}