using Plugins.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Plugins.ViewModels
{
	public class LocationListPageViewModel : ViewModelBase
	{
        private readonly Realm _realm;
        public LocationListPageViewModel(INavigationService navigationService, Realm realm)
            : base(navigationService)
        {
            Title = "Saved List";
            _realm = realm;
            Locations = new ObservableCollection<UserLocation>();
            LoadLocationsFromLocalDatabase();
        }

        private void LoadLocationsFromLocalDatabase()
        {
            IsRunning = true;
            var allLocations = _realm.All<UserLocation>();
            foreach (var item in allLocations)
            {
                Locations.Add(item);
            }
            IsRunning = false;

        }

        private ObservableCollection<UserLocation> locations;
        public ObservableCollection<UserLocation> Locations
        {
            get { return locations; }
            set { SetProperty(ref locations, value); }
        }
    }
}
