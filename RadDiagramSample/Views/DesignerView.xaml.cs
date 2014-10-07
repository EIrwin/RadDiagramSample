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
        public DesignerView()
        {
            InitializeComponent();
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            DesignerViewModel model = Diagram.DataContext as DesignerViewModel;
            model.Generate();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DesignerViewModel model = Diagram.DataContext as DesignerViewModel;
            model.Save();
        }
    }
}
