using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismSeries.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private bool isRunning = false;
        private bool isNotRunning = true;

        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                SetProperty(ref isRunning, value);
                SetProperty(ref isNotRunning, !value);
            }
        }

        public bool IsNotRunning
        {
            get
            {
                return isNotRunning;
            }
            set
            {
                SetProperty(ref isNotRunning, value);

            }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }

        public virtual void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }

        public virtual void Destroy()
        {
            
        }
    }
}
