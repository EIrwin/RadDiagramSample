using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadDiagramSample.ViewModels
{
    public class WhereViewModel:ControlViewModel
    {
        public WhereViewModel(Type componentType) : base(componentType)
        {
            this.Expandable = true;
        }
    }
}
