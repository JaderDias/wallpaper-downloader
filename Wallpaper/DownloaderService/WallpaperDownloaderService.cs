﻿using System;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using DownloaderService.Properties;
using Wallpaper;
using Microsoft.Win32;

namespace DownloaderService
{
    public partial class WallpaperDownloaderService : ServiceBase
    {
        static readonly long MillissecondsToTicksRatio = 10000;
        static readonly object classLock = new object();

        public System.Threading.Timer Timer { get; set; }

        public WallpaperDownloaderService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var dueTime = Settings.Default.DueTime.Ticks / MillissecondsToTicksRatio;
            var period = Settings.Default.Period.Ticks / MillissecondsToTicksRatio;
            this.Timer = new System.Threading.Timer(TimerCallback, null, dueTime, period);
        }

        protected override void OnStop()
        {
            this.Timer.Dispose();
            this.Timer = null;
        }

        protected void TimerCallback(object state)
        {
            if (Monitor.TryEnter(classLock))
            {
                lock (classLock)
                {
                    var resolution = Model.GetRegistryValue("Resolution");
                    var outputFolder = Model.GetRegistryValue("WallpaperOutputFolder");
                    Downloader.Instance.DownloadFeeds(resolution, outputFolder);
                    Downloader.Instance.DownloadAPage(resolution, outputFolder, Settings.Default.CurrentPage);
                    Settings.Default.CurrentPage++;
                    Settings.Default.Save();
                }
            }
        }
    }
}
