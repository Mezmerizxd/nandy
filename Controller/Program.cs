namespace Controller
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var dashboard = new Dashboard();

            Logger.Initialize(dashboard);
            Logger.Log("Starting application...", Logger.TYPE.INFO);

            Application.Run(dashboard);
        }
    }
}