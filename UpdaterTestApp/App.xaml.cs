using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using wyDay.Controls;

namespace UpdaterTestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _mainWin;
        private AutomaticUpdater autoUpdater;
        private UpdaterWindow updaterWindow;
        public App()
        {

        }

        private void AppInit()
        {
            _mainWin = new MainWindow(autoUpdater);
            _mainWin.Show();
            updaterWindow.Show();
        }

        void autoUpdater_ClosingAborted(object sender, EventArgs e)
        {
            AppInit();
            updaterWindow.Hide();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
           // _mainWin = new MainWindow();
           // _mainWin.Show();
            updaterWindow = new UpdaterWindow();
            autoUpdater = updaterWindow.autoUpdater;
            if (!autoUpdater.ClosingForInstall)
            {
                AppInit();
            }
            else    // If we're about to close, don't load anything
            {
                autoUpdater.ClosingAborted += new EventHandler(autoUpdater_ClosingAborted);
            }
        }
    }
}
