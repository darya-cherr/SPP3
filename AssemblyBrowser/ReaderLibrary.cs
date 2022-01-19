using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace AssemblyBrowser
{
    public class ReaderLibrary : IReader
    {
        private Assembly asm;
        public List<InfoFormatter> typeList;
        
        private List<MethodInfo> GetMethods(Type type)
        {
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (var method in type.GetMethods())
            {
                if (method.Module.Name == "TestClass.dll")
                {
                    methods.Insert(0, method);
                }
            }
            return methods;
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
        
        private List<Type> GetTypes()
        {
            List<Type> types = new List<Type>();
            foreach (var type in asm.GetTypes())
            {
                if (type.Namespace != "System.Runtime.CompilerServices" && type.Namespace != "Microsoft.CodeAnalysis")
                    types.Insert(0,type);
            }
            return types;
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
            typeList = new List<InfoFormatter>();
            List<Type> asmTypes = GetTypes();
            foreach (var type in asmTypes)
            {
                InfoFormatter format = new InfoFormatter();
                format._nameSpace = type.Namespace;
                format._type = type.Name;
                format._fields = GetFields(type).ToList();
                format._methods = GetMethods(type);
                format._properties = GetProperties(type).ToList();
                typeList.Add(format);
            }
        }
    }
}