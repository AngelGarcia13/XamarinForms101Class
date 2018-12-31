using Prism;
using Prism.Ioc;
using PrismSeries.ViewModels;
using PrismSeries.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Unity;
using PrismSeries.Services;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismSeries
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/SeriesListPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();

            containerRegistry.RegisterForNavigation<SeriesListPage>();
            containerRegistry.Register<ISeriesService, SeriesService>();
            containerRegistry.RegisterForNavigation<SerieDetailsPage>();
        }
        protected override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("android=287f1917-1dc3-4a08-b3f9-c64467eb08d3;", typeof(Analytics), typeof(Crashes));
        }
    }
}
