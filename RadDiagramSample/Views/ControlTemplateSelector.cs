using System.Windows.Controls;

namespace RadDiagramSample.Views
{
    public class ControlTemplateSelector:DataTemplateSelector
    {
        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            //Retrieve 'announced' DataTemplate based on
            //state informtion from 'item' parameter

            return base.SelectTemplate(item, container);
        }
    }
}
