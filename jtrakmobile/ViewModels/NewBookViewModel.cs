using jtrakmobile.Infrastructure.Api;
using jtrakmobile.Infrastructure.DB;
using jtrakmobile.Models;
using Prism.AppModel;
using Prism.Commands;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace jtrakmobile.ViewModels
{
    public class NewBookViewModel : IPageLifecycleAware
    {
        private readonly IApiManager<Book> apiRepository;
        private readonly IDbManager<Book> dbRepository;

        public ObservableCollection<Book> SearchResults { get; set; }
        public ICommand AddCommand { get; set; }

        public NewBookViewModel(IApiManager<Book> apiRepository, IDbManager<Book> dbRepository)
        {
            this.apiRepository = apiRepository;
            this.dbRepository = dbRepository;
            SearchResults = new ObservableCollection<Book>();
            AddCommand = new DelegateCommand<object>(AddImpl, CanAdd);
        }

        private async Task GetBooks()
        {
            List<Book> books = await this.apiRepository.GetAsync();

            SearchResults.Clear();
            books.ForEach(SearchResults.Add);
        }

        private void AddImpl(object source)
        {
            bool success = false;

            if (source is ListView listView
                && listView.SelectedItem is Book book)
            {
                success = this.dbRepository.Insert(book);
            }

            if (success)
            {
                App.Current.MainPage.DisplayAlert("Success", "Book saved", "OK");
            }
            else
            {
                App.Current.MainPage.DisplayAlert("Failure", "An error has occurred while saving the book", "OK");
            }
        }

        private bool CanAdd(object source) => source is ListView listView && listView.SelectedItem != null;

        public async void OnAppearing()
        {
            await GetBooks();
        }

        public void OnDisappearing()
        {
        }
    }
}
