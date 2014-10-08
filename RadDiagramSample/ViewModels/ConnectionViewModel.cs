using System;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace RadDiagramSample.ViewModels
{
    public class ConnectionViewModel : LinkViewModelBase<ControlViewModel>
    {
        public string Id { get; set; }
    }
}