using System.Collections.Generic;
using System.Reflection;

namespace AssemblyBrowser
{
    public class InfoFormatter
    {
        public string _nameSpace;
        public string _class;
        public List<MethodInfo> _methods;
        public List<PropertyInfo> _properties;
        public List<FieldInfo> _fields;


        public InfoFormatter()
        {
            _nameSpace = "";
            _class = "";
            _methods = new List<MethodInfo>();
            _properties = new List<PropertyInfo>();
            _fields = new List<FieldInfo>();
        }
        
        
    }
    
    
}