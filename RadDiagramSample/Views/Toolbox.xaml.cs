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
                            Content = "Component A",
                            DataContext = new ListBoxViewModel()
                                {
                                    ComponentType = typeof (ComponentA),
                                    Name = "Component A"
                                }
                        },
                    new ListBoxItem()
                        {
                            Content = "Component B",
                            DataContext = new ListBoxViewModel()
                                {
                                    ComponentType = typeof (ComponentB),
                                    Name = "Component B"
                                }
                        },
                    new ListBoxItem()
                        {
                            Content = "Component C",
                            DataContext = new ListBoxViewModel()
                                {
                                    ComponentType = typeof (ComponentC),
                                    Name = "Component C"
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
