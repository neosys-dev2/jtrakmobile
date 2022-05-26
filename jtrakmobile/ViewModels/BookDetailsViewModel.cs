using jtrakmobile.Models;
using Prism.Commands;
using Prism.Navigation;
using System.ComponentModel;
using System.Windows.Input;

namespace jtrakmobile.ViewModels
{
    public class BookDetailsViewModel : INavigatedAware, INotifyPropertyChanged
    {
        private string title;
        private string author;
        private Book selectedBook;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("title");
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                author = value;
                OnPropertyChanged("Author");
            }
        }

        public ICommand DeleteBookCommand { get; set; }

        public BookDetailsViewModel()
        {
            DeleteBookCommand = new DelegateCommand(DeleteBookImpl);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            this.selectedBook = (Book)parameters[Strings.SelectedBook];

            Title = selectedBook.Title;
            Author = selectedBook.Author;
        }

        private void DeleteBookImpl()
        {
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
