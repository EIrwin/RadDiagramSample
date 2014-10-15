namespace RadDiagramSample.Models
{
    public class ContextBarItem
    {
        public object Value { get; set; }

        public ContextBarItem() { }

        public ContextBarItem(object value)
        {
            Value = value;
        }

        public override string ToString()
        {
            if (Value != null)
                return Value.ToString();

            return base.ToString();
        }
    }
}