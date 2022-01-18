using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace WpfApp.ViewModel
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly AssemblyBrowser.ReaderLibrary reader = new AssemblyBrowser.ReaderLibrary();

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        
    }
}