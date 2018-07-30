using ListViews.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ListViews.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigation navigationService;
        private string empleadoSeleccionado = "Seleccione un empleado";
        public string EmpleadoSeleccionado
        {
            get
            {
                return empleadoSeleccionado;
            }
            set
            {
                if (empleadoSeleccionado != value)
                {
                    empleadoSeleccionado = value;
                    OnPropertyChanged("EmpleadoSeleccionado");
                }
            }
        }
        private Empleado empleado;
        public Empleado Empleado
        {
            get
            {
                return empleado;
            }
            set
            {
                empleado = value;

                if (empleado == null)
                {
                    return;
                }

                VerDetallesCommand.Execute(empleado);

                Empleado = null;
            }
        }
        public ObservableCollection<Empleado> Empleados { get; set; }
        public ICommand AgregarCommand { get; private set; }
        public ICommand VerDetallesCommand { get; private set; }
        public MainViewModel()
        {
            Empleados = new ObservableCollection<Empleado>();
            AgregarCommand = new Command(Agregar);
            VerDetallesCommand = new Command<Empleado>(VerDetalles);
            GetEmpleados();
        }

        private void VerDetalles(Empleado obj)
        {
            navigationService.PushAsync(new Detalle(obj));
            //EmpleadoSeleccionado = $"{obj.Nombre} - {obj.Ocupacion}";
        }

        void Agregar()
        {
            Empleados.Add(new Empleado
            {
                Nombre = "Nuevo Empleado",
                Ocupacion = "....."
            });
        }

        async void GetEmpleados()
        {
            //Voy a la NASA y traigo los datos...
            IsRunning = true;
            await Task.Delay(10000);
            var resultado = GetNasaEmployees();
            IsRunning = false;
            foreach (var item in resultado)
            {
                Empleados.Add(item);
            }
        }
        public ObservableCollection<Empleado> GetNasaEmployees()
        {
            return new ObservableCollection<Empleado>
            {
                new Empleado{
                    Nombre = "Juan Carlos",
                    Ocupacion = "Mecánico de Aviación"
                },
                new Empleado{
                    Nombre = "Leslie Altagracia",
                    Ocupacion = "Estudiante"
                },
                new Empleado{
                    Nombre = "Angel Rene",
                    Ocupacion = "Pegabló"
                }
            };
        }
    }
}
