using ListViews.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListViews
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            var vm = new MainViewModel();
            vm.navigationService = Navigation;
            BindingContext = vm;
		}
	}
}
