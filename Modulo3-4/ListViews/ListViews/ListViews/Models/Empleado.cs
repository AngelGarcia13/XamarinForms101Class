using ListViews.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListViews.Models
{
    public class Empleado
    {
        public string Nombre { get; set; }
        public string Ocupacion { get; set; }
        public int Edad { get; set; }
        public Empleado()
        {
            Edad = 24;
        }
    }
}
