using jtrakmobile.Infrastructure.DB;
using jtrakmobile.Models;
using jtrakmobile.Infrastructure.Navigation;
using Prism.AppModel;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace jtrakmobile.ViewModels
{
    public class BooksViewModel : IPageLifecycleAware
    {
        private readonly INavigationService navigationService;
        private readonly IDbManager<Book> dbRepository;

        public ObservableCollection<Book> Books { get; set; }
        public ICommand AddBookCommand { get; set; }
        public ICommand ViewDetailsCommand { get; set; }

        public BooksViewModel(INavigationService navigationService, IDbManager<Book> dbRepository)
        {
            this.navigationService = navigationService;
            this.dbRepository = dbRepository;
            Books = new ObservableCollection<Book>();
            AddBookCommand = new DelegateCommand(AddBookImp);
            ViewDetailsCommand = new DelegateCommand<object>(ViewDetailsImpl);

            ReadSavedBooks();
        }

        private void ReadSavedBooks()
        {
            List<Book> books = this.dbRepository.GetAll();

            Books.Clear();
            books.ForEach(Books.Add);
        }

        private async void AddBookImp()
        {
            await this.navigationService.NavigateAsync(Routes.NewBookPage);
        }

        private async void ViewDetailsImpl(object source)
        {
            if (source is CollectionView list
                && list.SelectedItem is Book book)
            {
                NavigationParameters navigationParams = new NavigationParameters
                {
                    { Strings.SelectedBook, book }
                };

                await this.navigationService.NavigateAsync(Routes.BookDetailsPage, navigationParams);
            }
        }

        public void OnAppearing()
        {
            ReadSavedBooks();
        }

        public void OnDisappearing()
        {
        }
    }
}
