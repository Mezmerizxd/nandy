using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
  internal class Server
  {
    public static void Start()
    {
      Logger.Log("Starting server", Logger.TYPE.INFO);
    }

    public static void Stop()
    {
      Logger.Log("Stopping server", Logger.TYPE.INFO);
    }
  }
}
