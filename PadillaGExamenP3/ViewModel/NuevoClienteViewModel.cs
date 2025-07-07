using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PadillaGExamenP3.Models;
using PadillaGExamenP3.Data;
using System.IO;
using System.Threading.Tasks;
using System;

namespace PadillaGExamenP3.View
{
    public partial class NuevoClienteViewModel : ObservableObject
    {
        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string empresa;

        [ObservableProperty]
        private int antiguedadMeses;

        [ObservableProperty]
        private bool activo;

        // Comando para guardar el cliente
        [RelayCommand]
        public async Task GuardarClienteAsync()
        {
            // Validación de antigüedad (meses * 10 > 1500 días)
            if (AntiguedadMeses * 10 > 1500)
            {
                await App.Current.MainPage.DisplayAlert("Error", "La empresa tiene más de 1500 días de antigüedad.", "OK");
                return;
            }

            var nuevoCliente = new Cliente
            {
                Nombre = this.Nombre,
                Empresa = this.Empresa,
                AntiguedadMeses = this.AntiguedadMeses,
                Activo = this.Activo
            };

            // Guardar en base de datos
            await App.Database.SaveClienteAsync(nuevoCliente);

            // Guardar log
            string logEntry = $"Se incluyó el registro {nuevoCliente.Nombre} el {DateTime.Now:dd/MM/yyyy HH:mm}";
            string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Logs_Padilla.txt");
            File.AppendAllText(logPath, logEntry + Environment.NewLine);

            await App.Current.MainPage.DisplayAlert("Éxito", "Cliente guardado correctamente.", "OK");

            // Limpiar campos
            Nombre = string.Empty;
            Empresa = string.Empty;
            AntiguedadMeses = 0;
            Activo = false;
        }
    }
}
