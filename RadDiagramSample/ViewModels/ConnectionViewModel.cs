using System;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace RadDiagramSample.ViewModels
{
    public class ConnectionViewModel : LinkViewModelBase<ControlViewModel>
    {
        public string Id { get; set; }

        public object SourceConnector { get; set; }

        public object TargetConnector { get; set; }

        public string SourceConnectorPosition { get; set; }

        public string TargetConnectorPosition { get; set; }
    }
}