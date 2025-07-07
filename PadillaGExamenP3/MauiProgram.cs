
using Microsoft.Extensions.Logging;
using PadillaGExamenP3.Data;

namespace PadillaGExamenP3
{
    public static class MauiProgram
    {
        public static ClienteDatabase Database { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "clientes.db3");
            Database = new ClienteDatabase(dbPath);

            return builder.Build();
        }
    }
}
