using MyNotes.Shared;
using MyNotes.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace MyNotes.ViewModels
{
    class MainPageViewModel: BaseViewModel
    {
        public MainPageViewModel()
        {
            AllNotes = new ObservableCollection<string>();

            EraseCommand = new Command(() => 
            {
                AllNotes.Clear();
                TheNote = string.Empty;
            });

            SaveCommand = new Command(() =>
            {
                if(!string.IsNullOrEmpty(TheNote))
                { 
                    AllNotes.Add(TheNote);
                    TheNote = string.Empty;
                }
            });

            SelectionChangedCommand = new Command(async () =>
            {
                var detailVM = new DetailPageViewModel{
                    NoteText = SelectedNote 
                };

                var detailPage = new DetailPage();

                detailPage.BindingContext = detailVM;

                await Application.Current.MainPage.Navigation.PushModalAsync(detailPage);
            });
        }

        public ObservableCollection<string> AllNotes { get; set; }
        
        string theNote, selectedNote;

        public string TheNote 
        {
            get => theNote;
            set
            {
                theNote = value;
                this.Notify(nameof(TheNote));       
            }
        }

        public string SelectedNote
        {
            get => selectedNote;
            set
            {
                selectedNote = value;
                this.Notify(nameof(SelectedNote));
            }
        }

        public Command SaveCommand { get; }
        public Command EraseCommand { get; }
        public Command SelectionChangedCommand { get; }

    }
}
