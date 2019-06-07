using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSeries.Models;
using PrismSeries.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrismSeries.ViewModels
{
	public class SerieDetailsPageViewModel : ViewModelBase
    {
        private Serie serie;
        public Serie Serie
        {
            get { return serie; }
            set { SetProperty(ref serie, value); }
        }

        public SerieDetailsPageViewModel(INavigationService navigationService):
            base(navigationService)
        {
            Title = "Details";
        }
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Serie = (Serie)parameters["model"];
            var analyticsData = new Dictionary<string, string>
            {
                { "Name", Serie.Name }
            };
            Analytics.TrackEvent("Serie clicked", analyticsData);
            if (Serie.Name.Contains("Game of"))
            {
                Crashes.TrackError(new Exception("The winter is here!"));
            }
        }

    }
}
