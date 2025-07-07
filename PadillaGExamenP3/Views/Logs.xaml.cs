using System.IO;
using Microsoft.Maui.Controls;

namespace PadillaGExamenP3.Views
{
    public partial class Logs : ContentPage
    {
        public Logs()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            string logFileName = "Logs_Padilla.txt";
            string logPath = Path.Combine(FileSystem.AppDataDirectory, logFileName);

            if (File.Exists(logPath))
            {
                LogsLabel.Text = File.ReadAllText(logPath);
            }
            else
            {
                LogsLabel.Text = "No hay registros aún.";
            }
        }
    }
}
