using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;
using DownloaderService.Properties;
using System.Configuration;
using System.Windows.Forms;


namespace DownloaderService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        protected override void OnAfterInstall(System.Collections.IDictionary savedState)
        {
            base.OnAfterInstall(savedState);
            using (var serviceController = new ServiceController(this.serviceInstaller1.ServiceName, Environment.MachineName))
                serviceController.Start();
        }
    }
}
