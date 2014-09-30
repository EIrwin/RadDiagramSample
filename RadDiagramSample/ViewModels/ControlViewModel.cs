using System;
using Telerik.Windows.Controls.Diagrams.Extensions.ViewModels;

namespace RadDiagramSample.ViewModels
{
    public class ControlViewModel:NodeViewModelBase
    {
        public DateTime Timestamp { get; set; }

        public ControlViewModel()
        {
            Timestamp = DateTime.Now;
        }
    }
}