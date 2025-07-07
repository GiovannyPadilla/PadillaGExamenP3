using PadillaGExamenP3.Models; 
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace PadillaGExamenP3.ViewModels
{
    public class ListaClientesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cliente> Clientes { get; set; } = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public ListaClientesViewModel()
        {
            LoadClientes();
        }

        public async void LoadClientes()
        {
            var lista = await MauiProgram.Database.GetClientesAsync();
            Clientes.Clear();
            foreach (var cliente in lista)
                Clientes.Add(cliente);
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
