using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CRUDMVVMQ22025.Models;
using CRUDMVVMQ22025.Services;


namespace CRUDMVVMQ22025.ViewModels
{
    public partial class AddEditViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string direccion;

        [ObservableProperty]
        private string email;

        private readonly EmpleadoService _service;

        public AddEditViewModel() 
        {
            _service = new EmpleadoService();
        }

        public AddEditViewModel(Empleado Empleado) 
        {
            _service = new EmpleadoService();
            Id = Empleado.Id;
            Nombre = Empleado.Nombre;
            Direccion = Empleado.Direccion;
            Email = Empleado.Email;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                /*Empleado Empleado = new Empleado();
                Empleado.Id = Id;
                Empleado.Nombre = Nombre;
                Empleado.Direccion = Direccion;
                Empleado.Email = Email;*/

                Empleado Empleado = new Empleado()
                {
                    Id = Id,
                    Nombre = Nombre,
                    Direccion = Direccion,
                    Email = Email,
                };

                if(Empleado.Nombre == null || Empleado.Nombre == "")
                {
                    Alerta("ADVERTENCIA", "Nombre del empleado en blanco.");
                } else
                {
                    if (Id == 0)
                    {
                        _service.Insert(Empleado);
                    }
                    else
                    {
                        _service.Update(Empleado);
                    }

                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }
    }
}
