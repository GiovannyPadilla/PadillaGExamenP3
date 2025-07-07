using PadillaGExamenP3.Models;   // Aquí va tu modelo Cliente
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Maui.Storage;

namespace PadillaGExamenP3.Data
{
    public class ClienteDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public ClienteDatabase()
        {
            // Crear ruta de la base de datos en la carpeta de la app
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "clientes.db3");

            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Cliente>().Wait();
        }

        // Obtener todos los clientes
        public Task<List<Cliente>> GetClientesAsync()
        {
            return _database.Table<Cliente>().ToListAsync();
        }

        // Guardar un cliente (insertar)
        public Task<int> SaveClienteAsync(Cliente cliente)
        {
            return _database.InsertAsync(cliente);
        }
    }
}
