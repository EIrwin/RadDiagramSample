using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RadDiagramSample.Models;

namespace RadDiagramSample.ViewModels
{
    public static class ControlViewModelFactory
    {
        public static ControlViewModel Create(string typeName)
        {
            return Create(Type.GetType(typeName));
        }

        public static ControlViewModel Create(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            //We most likely need to retrieve
            //the necessary ControlViewModel implementation
            //by asking modules to announce the ControlViewModel

            return GetTempControlViewModel(type);
        }

        public static ControlViewModel GetTempControlViewModel(Type type)
        {
            if (type == typeof (ComponentA))
                return new ControlAViewModel(type);
            if (type == typeof (Constant))
                return new ConstantViewModel(type);

            throw new NotImplementedException();
        }
    }
}
