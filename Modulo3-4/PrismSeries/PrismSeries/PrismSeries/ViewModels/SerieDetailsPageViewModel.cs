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
            //_textToSpeech = textToSpeech;
            Title = "Details";
        }
        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
            Serie = (Serie)parameters["model"];
        }

    }
}
