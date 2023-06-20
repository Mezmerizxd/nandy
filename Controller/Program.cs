using System.Runtime.InteropServices;

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

      Logger.Initialize();
      Logger.Log("Starting application...", Logger.TYPE.INFO);

      // Check what platform we are running on
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
      {
        Logger.Log("Running on Windows", Logger.TYPE.INFO);
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
      {
        Logger.Log("Running on Linux", Logger.TYPE.INFO);
      }
      else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
      {
        Logger.Log("Running on OSX", Logger.TYPE.INFO);
      }
      else
      {
        Logger.Log("Running on unknown platform", Logger.TYPE.WARNING);
      }

      Thread TServer = new Thread(Server.Start);
      TServer.Start();

      Thread TSockets = new Thread(Sockets.Start);
      TSockets.Start();

      Application.Run(dashboard);
    }
  }
}