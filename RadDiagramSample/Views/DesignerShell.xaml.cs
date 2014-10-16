using System.Windows;
using RadDiagramSample.Events;
using RadDiagramSample.Models;
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
            ControlViewModel model = new ControlViewModel(typeof(SubRoutine)){Expandable = true};
            ViewModel.AddControl(model);
            this.Diagram.ViewModel = model;

            //We want to initialize the context bar with the 
            //control/component that we created above to give
            //context to where the user is at
            ContextBarItem initialItem = new ContextBarItem(model);
            this.ContextBar.AddItem(initialItem);

            //We need to handle the 'ControlClicked' event
            //that is bubbling up from the Designer because
            //we need to notify the ContextBar that an item
            //is being expanded
            this.Diagram.ControlClicked += Diagram_ControlClicked;

            //We want to handle the 'ItemClicked' event
            //fired by the ContextBar so that we can update
            //the designer surface to correctly display the state
            this.ContextBar.ItemClicked += ContextBar_ItemClicked;
        }

        private void ContextBar_ItemClicked(object sender, ItemClickedEventArgs e)
        {
            //Need to update the context bar and our list of controls

        }

        private void Diagram_ControlClicked(object sender, ControlClickedEventArgs e)
        {
            ControlViewModel model = (ControlViewModel) e.ControlView.DataContext;

            //We only want to allow a control to be
            //expanded if the 'Expandable' flag has been
            //explicitly set upon creation of the object
            if (model.Expandable)
            {
                ViewModel.AddControl(model);

                ContextBarItem item = new ContextBarItem(model);
                ContextBar.AddItem(item);

                Diagram.Clear();
            }
        }

        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
