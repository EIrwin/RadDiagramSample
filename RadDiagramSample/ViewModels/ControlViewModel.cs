 using System;
 using System.Collections.Generic;
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

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        private bool _expandable;
        public bool Expandable
        {
            get { return _expandable; }
            set
            {
                if (_expandable != value)
                {
                    _expandable = value;
                    OnPropertyChanged("Expandable");
                }
            }
        }

        public Type ComponentType { get; private set; }

        protected readonly IDictionary<string, ControlViewModel> Controls;
        protected readonly IDictionary<string, ConnectionViewModel> Connections;

        public ControlViewModel(Type componentType)
        {
            Timestamp = DateTime.Now;
            Id = Guid.NewGuid();
            ComponentType = componentType;

            Controls = new Dictionary<string, ControlViewModel>();
            Connections = new Dictionary<string,ConnectionViewModel>();
        }

        public void AddControl(ControlViewModel model)
        {
            Controls.Add(model.Id.ToString(), model);
        }

        public void RemoveControl(ControlViewModel model)
        {
            Controls.Remove(model.Id.ToString());
        }

        public void AddConnection(ConnectionViewModel model)
        {
            Connections.Add(model.Id, model);
        }

        public void RemoveConnection(string id)
        {
            Connections.Remove(id);
        }
    }
}