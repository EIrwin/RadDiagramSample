using System;
using System.Windows;
using System.Windows.Controls;
using RadDiagramSample.ViewModels;

namespace RadDiagramSample.Views
{
    public class ControlTemplateSelector:DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //Retrieve 'announced' DataTemplate based on
            //state informtion from 'item' parameter
            string controlName = ((ControlViewModel) item).Name;

            //We can temporarily pull a test template from application resource file
            DataTemplate template = (DataTemplate) GetTestResourceDictionary()[controlName + "Template"];
            return template;
        }

        private ResourceDictionary GetTestResourceDictionary()
        {
            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source =
                new Uri("/RadDiagramSample;component/Resources/TempResources.xaml",
                        UriKind.RelativeOrAbsolute);

            return resourceDictionary;
        }
    }
}
