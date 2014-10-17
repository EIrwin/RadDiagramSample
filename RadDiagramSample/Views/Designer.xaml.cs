using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using RadDiagramSample.Events;
using RadDiagramSample.ViewModels;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.Diagrams;
using Telerik.Windows.Diagrams.Core;

namespace RadDiagramSample.Views
{
    /// <summary>
    /// Interaction logic for Designer.xaml
    /// </summary>
    public partial class Designer : RadDiagram
    {
        private ControlViewModel _viewModel;
        public ControlViewModel ViewModel
        {
            get { return _viewModel; }
            set
            {
                DataContext = _viewModel;
                _viewModel = value;
            }
        }

        public Designer()
        {
            InitializeComponent();
        }

        private void Diagram_ConnectionManipulationCompleted(object sender, ManipulationRoutedEventArgs e)
        {
            if (e.Shape == null)
            {
                if (Diagram.Connections.Contains(e.ManipulationPoint.Connection))
                {
                    Diagram.RemoveConnection(e.ManipulationPoint.Connection);
                    ViewModel.RemoveConnection(e.Connection.Id);
                }

                e.Handled = true;
            }
            else
            {
                if (!Diagram.Connections.Any(p => p.Target == e.Connection.Target && p.Source == e.Connection.Source))
                {
                    //Check if connection already exists in 
                    ConnectionViewModel model = new ConnectionViewModel()
                        {
                            Id = e.Connection.Id,
                            Source =
                                ((ControlView) e.ManipulationPoint.Connection.Source).DataContext as ControlViewModel,
                            SourceCapType = CapType.None,
                            Target = ((ControlView) e.Shape).DataContext as ControlViewModel,
                            TargetCapType = CapType.Arrow1,
                            Position = e.ManipulationPoint.Position,
                        };

                    ViewModel.AddConnection(model);
                }
            }
        }

        private void Diagram_PreviewDrop(object sender, DragEventArgs e)
        {
            ListBoxItem listBoxItem = (ListBoxItem)e.Data.GetData(e.Data.GetFormats()[0]);
            ListBoxViewModel listBoxViewModel = (ListBoxViewModel)listBoxItem.DataContext;

            //Generate the ViewModel based on the business
            //object that the ListBoxViewModel references
            ControlViewModel model = ControlViewModelFactory.Create(listBoxViewModel.ComponentType);
            model.Position = e.GetPosition(Diagram);
            model.ViewType = listBoxViewModel.ViewType; //@Joe - should we do this?
            ViewModel.AddControl(model);

            //Generate the View based on the business
            //object that the ListBoxViewModel references
            ControlView view = ControlViewFactory.Create(listBoxViewModel.ViewType);
            view.DataContext = model;
            view.PreviewMouseLeftButtonDown += Diagram_ControlClicked;
            Diagram.AddShape(view);
        }

        private void Diagram_ControlClicked(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                ControlView view = (ControlView) sender;
                ViewModel = view.DataContext as ControlViewModel;
                ControlClicked(sender, new ControlClickedEventArgs(view));
            }
        }

        public void Load(ControlViewModel model)
        {
            Diagram.ViewModel = model;

            List<ControlViewModel> controls = new List<ControlViewModel>();

            if (model.GetConnections().Any())
            {
                foreach (ConnectionViewModel m in model.GetConnections())
                {
                    ControlViewModel source = model.GetControls().First(p => p.Id == m.Source.Id);
                    ControlView sourceView = ControlViewFactory.Create(source.ViewType);
                    sourceView.DataContext = source;
                    sourceView.Position = source.Position;
                    sourceView.PreviewMouseLeftButtonDown += Diagram_ControlClicked;

                    ControlViewModel target = model.GetControls().First(p => p.Id == m.Target.Id);
                    ControlView targetView = ControlViewFactory.Create(target.ViewType);
                    targetView.DataContext = target;
                    targetView.Position = target.Position;
                    targetView.PreviewMouseLeftButtonDown += Diagram_ControlClicked;

                    Diagram.AddConnection(sourceView,targetView);

                    if (!controls.Any(p => p.Id == source.Id))
                        Diagram.AddShape(sourceView);

                    if (!controls.Any(p => p.Id == target.Id))
                        Diagram.AddShape(targetView);
                }
            }
            foreach (ControlViewModel m in model.GetControls())
            {
                if (!controls.Any(p => p.Id == m.Id))
                {
                    ControlView view = ControlViewFactory.Create(m.ViewType);
                    view.DataContext = m;
                    view.Position = m.Position;
                    view.PreviewMouseLeftButtonDown += Diagram_ControlClicked;
                    Diagram.AddShape(view);
                }
            }
        }

        public EventHandler<ControlClickedEventArgs> ControlClicked { get; set; }
    }

    
}
