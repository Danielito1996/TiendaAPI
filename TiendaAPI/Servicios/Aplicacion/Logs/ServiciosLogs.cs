namespace TiendaAPI.Servicios.Aplicacion.Logs
{
    public class ServiciosLogs:IServiciosLogs
    {
        private string _logFilePath;
        public ServiciosLogs()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string logFolder = Path.Combine(docPath, "API", "Log");
            if (!Directory.Exists(logFolder))
            {
                Directory.CreateDirectory(logFolder);
            }
            _logFilePath = Path.Combine(logFolder, "app.log");
        }
        public async Task Log(string message)
        {
            using (StreamWriter streamWriter = new StreamWriter(_logFilePath, true))
            {
                streamWriter.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }
}
