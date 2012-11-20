using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace UpdaterTestApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow _mainWin;
        public App()
        {

        }
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            _mainWin = new MainWindow();
            _mainWin.Show();
        }
    }
}
