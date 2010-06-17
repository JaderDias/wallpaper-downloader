using System.ServiceProcess;

namespace DownloaderService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new WallpaperDownloaderService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
