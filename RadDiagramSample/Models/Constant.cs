using System.Collections.Generic;
using System.Linq;
using System.Text;
using RadDiagramSample.Scripting;

namespace RadDiagramSample.Models
{
    public class Constant:IScriptGenerator,
                          IComponentGenerator
    {
        public string Generate(ComponentElement component, IDictionary<string, string> inputs)
        {
            var builder = new StringBuilder();
            builder.Append("(function(){ return '").Append(component.Properties.Single(p => p.Name == "DroppedItem").Value).Append("'; }())");
            return builder.ToString();
        }

        public ComponentElement Generate()
        {
            var component = new ComponentElement();
            component.Generator = GetType().AssemblyQualifiedName;
            component.Name = "Constant";
            component.Description = "Specify a constant value";

            var outputPort = new PortElement() { Name = "Result", Type = PortDirection.Output };

            component.Properties.Add(new PropertyElement { Name = "Value", Value = "10" });
            component.Ports.AddRange(new[] { outputPort });

            return component;
        }
    }
}
