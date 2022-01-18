using System;
using System.Reflection;

namespace AssemblyBrowser
{
    public class ReaderLibrary : IReader
    {
        private Assembly asm;
        
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
        
        public void GetResult(string path)
        {
            asm = LoadAssembly(path);
            Type[] asmTypes = GetTypes();
            
        }
    }
}