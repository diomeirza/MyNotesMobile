using MyNotes.Shared;
using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyNotes.ViewModels
{
    class DetailPageViewModel : BaseViewModel
    {
        public DetailPageViewModel()
        {
            DismissCommand = new Command(async () =>
            {
               await Application.Current.MainPage.Navigation.PopModalAsync();
            });
        }

        string noteText;

        public string NoteText
        {
            get => noteText;
            set
            {
                noteText = value;
                this.Notify(nameof(NoteText));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Command DismissCommand { get; }
    }
}
