namespace RadDiagramSample.Models
{
    public class ComponentA:IDomainComponent
    {
        public string GetTypeName()
        {
            return this.GetType().FullName;
        }
    }
}