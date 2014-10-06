using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using RadDiagramSample.Models;
using RadDiagramSample.ViewModels;

namespace RadDiagramSample.Views
{
    /// <summary>
    /// Interaction logic for Toolbox.xaml
    /// </summary>
    public partial class Toolbox : UserControl
    {
        public Toolbox()
        {
            InitializeComponent();

            InitializeToolbox();
        }

        public void InitializeToolbox()
        {
            List<ListBoxItem> listBoxItems = new List<ListBoxItem>()
                {
                    new ListBoxItem()
                        {
                            Content = "Constant",
                            DataContext = new ListBoxViewModel()
                                {
                                    ComponentType = typeof(Constant),
                                    ViewType = typeof(ConstantView),
                                    Name = "Constant"
                                }
                        },
                    new ListBoxItem()
                        {
                            Content = "Component A",
                            DataContext = new ListBoxViewModel()
                                {
                                    ComponentType = typeof (ComponentA),
                                    ViewType = typeof(ControlAView),
                                    Name = "Component A"
                                }
                        }
                };

            listBoxItems.ForEach(item =>
                {
                    item.PreviewMouseLeftButtonDown += (o, e) =>
                        {
                            var sender = (ListBoxItem) o;
                            DragDrop.DoDragDrop((DependencyObject) o, sender, DragDropEffects.All);
                        };

                    TbToolbox.Items.Add(item);
                });

             
        }
    }
}
