using System.Collections.Generic;
using System.Reflection;
using System.Text;

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
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append($"Methods - \n{WriteMethods()}\n Properties - \n{WriteProperties()}\n " +
                           $"Fields - \n{WriteFields()}");

            return builder.ToString();
        }
        
        private string WriteMethods()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var method in _methods)
            {
                builder.Append("\t" + method.ReturnType.Name + " " + method.Name + " (");
                ParameterInfo[] parameters = method.GetParameters();
                if (parameters.Length != 0)
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        var par = parameters[i];
                        if (i == parameters.Length - 1)
                            builder.Append(par + ")\n");
                        else
                            builder.Append(par + ", ");
                    }
                else
                {
                    builder.Append(")\n");
                }
            }
            return builder.ToString();
        }

        private string WriteProperties()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var prop in _properties)
            {
                builder.Append("\t" + prop.Name + "\n");
            }
            return builder.ToString();
        }

        private string WriteFields()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var field in _fields)
            {
                builder.Append("\t" + field.Name + "\n");
            }
            return builder.ToString();
        }
        
        
    }
    
    
}