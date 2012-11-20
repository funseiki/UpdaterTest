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
            Exit += new ExitEventHandler(App_Exit);
        }

        private void CloseWindows()
        {
            if (updaterWindow != null)
            {
                updaterWindow.Close();
                updaterWindow = null;
            }
        }
        void App_Exit(object sender, ExitEventArgs e)
        {
            CloseWindows();
        }

        void autoUpdater_ClosingAborted(object sender, EventArgs e)
        {
            AppInit();
            updaterWindow.Hide();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
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
