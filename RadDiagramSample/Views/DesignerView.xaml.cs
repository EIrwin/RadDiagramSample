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
            //We most likely want to create this ViewModel
            //from a factory that creates it from business object
            ControlViewModel model = new ControlViewModel()
            {
                Position = e.GetPosition(this.Diagram),
            };

            ViewModel.AddControl(model);
        }
    }
}
