using System;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace RadDiagramSample.ViewModels
{
    public class ConnectionViewModel : LinkViewModelBase<ControlViewModel>
    {
        public Guid ID { get; set; }

        public ConnectionViewModel()
        {
            ID = Guid.NewGuid();
        }
    }
}