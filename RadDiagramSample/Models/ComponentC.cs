namespace RadDiagramSample.Models
{
    public class ComponentC:IDomainComponent
    {
        public string GetTypeName()
        {
            return this.GetType().FullName;
        }
    }
}