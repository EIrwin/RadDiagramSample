using System.Collections.Generic;

namespace RadDiagramSample.Scripting
{
    public interface IScriptGenerator
    {
        string Generate(ComponentElement component, IDictionary<string, string> inputs);
    }
}