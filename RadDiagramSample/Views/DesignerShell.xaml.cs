using System.Windows;
using RadDiagramSample.ViewModels;

namespace RadDiagramSample.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DesignerShell : Window
    {
        public DesignerShellViewModel ViewModel;

        public DesignerShell()
        {
            InitializeComponent();

            ViewModel = new DesignerShellViewModel();
            DataContext = ViewModel;

            //The designer surface is actually just an expanded
            //control/component. We need to make sure to add an initial
            //ControlViewModel object with the 'Expandable' property set to true
            ControlViewModel model = new ControlViewModel(){Expandable = true};
            ViewModel.AddControl(model);
            this.Diagram.ViewModel = model;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
