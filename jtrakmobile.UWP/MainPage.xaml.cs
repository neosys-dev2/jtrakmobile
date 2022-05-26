using Prism;
using Prism.Ioc;
using System.IO;

namespace jtrakmobile.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            string fileName = "books.db3";
            string folderPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string fullPath = Path.Combine(folderPath, fileName);

            LoadApplication(new jtrakmobile.App(fullPath, new UwpPlatformInitializer()));
        }

        public class UwpPlatformInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
            }
        }
    }
}
