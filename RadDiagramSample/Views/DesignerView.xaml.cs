using System;
using System.Windows;
using System.Windows.Controls;
using RadDiagramSample.Models;
using RadDiagramSample.ViewModels;
using DragEventArgs = System.Windows.DragEventArgs;

namespace RadDiagramSample.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DesignerView : Window
    {
        private DesignerViewModel ViewModel;

        public DesignerView()
        {
            InitializeComponent();

            ViewModel = new DesignerViewModel();

            this.DataContext = ViewModel;
        }

        private void RadDiagram_PreviewDrop(object sender, DragEventArgs e)
        {
            ListBoxItem listBoxItem = (ListBoxItem) e.Data.GetData(e.Data.GetFormats()[0]);
            ListBoxViewModel listBoxViewModel = (ListBoxViewModel) listBoxItem.DataContext;

            ControlViewModel model = ControlViewModelFactory.Create(listBoxViewModel.ComponentType);
            model.Position = e.GetPosition(this.Diagram);

            ControlView view = ControlViewFactory.Create(listBoxViewModel.ViewType);
            view.DataContext = model;

            //Do we need both of these
            Diagram.AddShape(view);
            ViewModel.AddControl(model);
        }
    }
}
