using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AssemblyBrowser;
using JetBrains.Annotations;
using Microsoft.Win32;

namespace WpfApp.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public ICommand ButtonClickCommand => new ButtonClickCommand(OpenFile);
        
        public List<InfoFormatter> _list = new List<InfoFormatter>();
        public List<InfoFormatter> List
        {
            get  
            {  
                return _list;  
            }  
            set  
            {  
                _list = value;
                OnPropertyChanged(nameof(List));  
            }  
        }

        private void OpenFile()
        {
            AssemblyBrowser.ReaderLibrary reader = new AssemblyBrowser.ReaderLibrary();
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Assemblies|*.dll;*.exe", Title = "Select assembly", Multiselect = false
            };
            var isOpen = openFileDialog.ShowDialog();
            if (isOpen != null && isOpen.Value)
            {
                reader.GetResult(openFileDialog.FileName); 
                List = reader.typeList;
            }
            else
            { 
                System.Windows.MessageBox.Show("error");
            }
        }
    }
}