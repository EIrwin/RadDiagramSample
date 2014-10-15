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

            DesignerViewModel designerViewModel = new DesignerViewModel();

            ViewModel.AddDesigner(designerViewModel);

            this.Diagram.ViewModel = designerViewModel;
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ContextBar_ItemClicked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
