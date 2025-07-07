using PadillaGExamenP3.Data;
using System.IO;

namespace PadillaGExamenP3
{
    public partial class App : Application
    {
        public static ClienteDatabase Database { get; private set; }

        public App()
        {
            InitializeComponent();

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "clientes.db3");
            Database = new ClienteDatabase(dbPath);

            MainPage = new AppShell();
        }
    }
}
