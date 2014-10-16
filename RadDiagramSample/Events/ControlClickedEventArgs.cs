using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using RadDiagramSample.Views;

namespace RadDiagramSample.Events
{
    public class ControlClickedEventArgs : RoutedEventArgs
    {
        public ControlView ControlView { get; set; }

        public ControlClickedEventArgs(ControlView controlView)
        {
            ControlView = controlView;
        }
    }
}
