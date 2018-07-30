using ListViews.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ListViews.ViewModels
{
    public class DetailsViewModel : BaseViewModel
    {

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
            }
        }
    }
}
