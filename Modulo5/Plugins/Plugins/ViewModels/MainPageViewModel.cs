using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using Plugins.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plugins.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private readonly Realm _realm;
        public MainPageViewModel(INavigationService navigationService, Realm realm) 
            : base (navigationService)
        {
            CurrentLocation = "Tap the button to get location!";
            Title = "Main Page";
            _realm = realm;
        }
        private string currentLocation;
        public string CurrentLocation
        {
            get { return currentLocation; }
            set { SetProperty(ref currentLocation, value); }
        }

        private DelegateCommand getLocationCommand;
        public DelegateCommand GetLocationCommand =>
            getLocationCommand ?? (getLocationCommand = new DelegateCommand(ExecuteGetLocationCommandAsync));

        private DelegateCommand viewListCommand;
        public DelegateCommand ViewListCommand =>
            viewListCommand ?? (viewListCommand = new DelegateCommand(ExecuteViewListAsync));

        async void ExecuteViewListAsync()
        {
            await NavigationService.NavigateAsync("LocationListPage");
        }
        async void ExecuteGetLocationCommandAsync()
        {
            var position = await GetCurrentPosition();
            if (position != null)
            {
                CurrentLocation = $"Long.: {position.Longitude}, Lat.: {position.Latitude}";
                _realm.Write(() =>
                {
                    _realm.Add(new UserLocation { Value = CurrentLocation});
                });
                
            }
        }
        public async Task<Position> GetCurrentPosition() {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();
                if (position != null) {
                    return position;
                }
                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10), null, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                CurrentLocation = "Unable to get user's location";
            }
            return null;
        }
        public bool IsLocationAvailable()
        {
            return CrossGeolocator.Current.IsGeolocationAvailable;
        }
    }
}
