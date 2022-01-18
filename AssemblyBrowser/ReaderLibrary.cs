using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AssemblyBrowser
{
    public class ReaderLibrary : IReader
    {
        private Assembly asm;
        List<InfoFormatter> typeList = new List<InfoFormatter>();
        
        private MethodInfo[] GetMethods(Type type)
        {
            return type.GetMethods();
        }
        
        private FieldInfo[] GetFields(Type type)
        {
            return type.GetFields();;
        }
        
        private PropertyInfo[] GetProperties(Type type)
        {
            return type.GetProperties();
        }
        
        private Assembly LoadAssembly(string path)
        {
            return Assembly.LoadFrom(path);;
        }
        
        private Type[] GetTypes()
        {
            return asm.GetTypes();
        }
        
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var frame in typeList)
            {
                builder.Append($"{frame.ToString()}");    
            }
            
            return builder.ToString();
        }
        
        public void GetResult(string path)
        {
            asm = LoadAssembly(path);
            Type[] asmTypes = GetTypes();
            foreach (var type in asmTypes)
            {
                InfoFormatter format = new InfoFormatter();
                format._nameSpace = type.Namespace;
                format._class = type.Name;
                format._fields = GetFields(type).ToList();
                format._methods = GetMethods(type).ToList();
                format._properties = GetProperties(type).ToList();
                typeList.Add(format);
            }
        }
    }
}