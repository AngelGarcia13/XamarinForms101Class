using ListViews.Models;
using ListViews.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Detalle : ContentPage
	{
		public Detalle (Empleado empleado)
		{
			InitializeComponent ();
            var vm = new DetailsViewModel();
            vm.Empleado = empleado;
            BindingContext = vm;
        }
	}
}