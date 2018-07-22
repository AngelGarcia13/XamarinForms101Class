using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public class Empleado : BaseViewModel
    {
        string nombre = "Pirulo";
        string ocupacion = "Pegabó";
        int contador = 0;
        string textoPlano = "Líneas de código";
        public ICommand ContarCommand { get; private set; }
        public string TextoPlano
        {
            get
            {
                return textoPlano;
            }
            set
            {
                if (textoPlano != value)
                {
                    textoPlano = value;
                    OnPropertyChanged("TextoPlano");
                }
            }
        }
        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                if (nombre != value)
                {
                    nombre = value;
                    OnPropertyChanged("Nombre");
                }
            }
        }
        public string Ocupacion
        {
            get
            {
                return ocupacion;
            }
            set
            {
                if (ocupacion != value)
                {
                    ocupacion = value;
                    OnPropertyChanged("Ocupacion");
                }
            }
        }
        public int Contador
        {
            get
            {
                return contador;
            }
            set
            {
                if (contador != value)
                {
                    contador = value;
                    OnPropertyChanged("Contador");
                }
            }
        }
        public Empleado()
        {
            ContarCommand = new Command(Contar);
        }

        async void Contar()
        {
            IsRunning = true;
            IsEnabled = false;
            await Task.Delay(3000);
            Contador++;
            IsRunning = false;
            IsEnabled = true;
        }
        bool isEnabled = true;
        public bool IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;
                    OnPropertyChanged("IsEnabled");
                }
            }
        }
        bool isRunning = false;
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                if (isRunning != value)
                {
                    isRunning = value;
                    OnPropertyChanged("IsRunning");
                }
            }
        }
    }
}
