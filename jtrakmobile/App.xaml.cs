using jtrakmobile.Infrastructure.Api;
using jtrakmobile.Infrastructure.DB;
using jtrakmobile.Models;
using jtrakmobile.ViewModels;
using jtrakmobile.Views;
using Prism;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jtrakmobile
{
    public partial class App : PrismApplication
    {
        public static string ApiUrl = "https://api-jtrak.azurewebsites.net/api";
        public static string ApiKey = "JaD8VSmg6IXKqICqDfbRDSn3d1H0P10tlSksUVEMk79UAzFuFaY4Uw==";
        public static string DatabasePath;

        public App(string databasePath, IPlatformInitializer initializer = null) : base(initializer)
        {
            DatabasePath = databasePath;
            NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(BooksPage)}");
        }

        protected override void OnInitialized()
        {
            InitializeComponent();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IApiManager<Book>, BookApiManager>();
            containerRegistry.Register<IDbManager<Book>, BookDbManager>();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<BooksPage, BooksViewModel>();
            containerRegistry.RegisterForNavigation<NewBookPage, NewBookViewModel>();
            containerRegistry.RegisterForNavigation<BookDetailsPage, BookDetailsViewModel>();
        }
    }
}
