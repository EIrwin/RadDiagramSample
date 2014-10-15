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

            //Initialize DesignerShellViewModel here
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
