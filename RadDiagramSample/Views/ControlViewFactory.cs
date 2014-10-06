using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadDiagramSample.Views
{
    public static class ControlViewFactory
    {
        public static ControlView Create(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");

            return Activator.CreateInstance(type) as ControlView;
        }
        

        public static ControlView Create(string typeName)
        {
            return Create(Type.GetType(typeName));
        }
    }
}
