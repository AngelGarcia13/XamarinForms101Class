using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSeries.Models;
using PrismSeries.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrismSeries.ViewModels
{
    public class SeriesListPageViewModel : ViewModelBase
    {
        private readonly ISeriesService _seriesService;
        public SeriesListPageViewModel(INavigationService navigationService, ISeriesService seriesService) :
            base(navigationService)
        {
            _seriesService = seriesService;
            Title = "Prism Series";
            SeriesList = new ObservableCollection<Serie>();
            GetSeriesFromAPI();
        }
        private ObservableCollection<Serie> seriesList;
        public ObservableCollection<Serie> SeriesList
        {
            get { return seriesList; }
            set { SetProperty(ref seriesList, value); }
        }

        async void GetSeriesFromAPI()
        {
            IsRunning = true;
            var result = await _seriesService.GetAllSeriesAsync();
            IsRunning = false;
            foreach (var item in result)
            {
                SeriesList.Add(item);
            }
            
        }
    }
}
