namespace RadDiagramSample.Models
{
    public class ComponentB:IDomainComponent
    {
        public string GetTypeName()
        {
            return this.GetType().FullName;
        }
    }
}