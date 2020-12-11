using System.ComponentModel;

namespace MyNotes.Shared
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propertyName)
        {
            var args = new PropertyChangedEventArgs(nameof(propertyName));
            PropertyChanged?.Invoke(this, args);
        }
    }
}
