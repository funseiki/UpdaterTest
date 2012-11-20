using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using wyDay.Controls;

namespace UpdaterTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AutomaticUpdater autoUpdater;
        public MainWindow(AutomaticUpdater _au)
        {
            InitializeComponent();
            autoUpdater = _au;
            if (autoUpdater.UpdateStepOn == wyDay.Controls.UpdateStepOn.UpdateReadyToInstall)
            {
                autoUpdater_ReadyToBeInstalled(this, null);
            }
            else
            {
                autoUpdater.ReadyToBeInstalled += new EventHandler(autoUpdater_ReadyToBeInstalled);
            }
            
        }

        private void autoUpdater_ReadyToBeInstalled(object sender, EventArgs e)
        {
            UpdateButton.Visibility = Visibility.Visible;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            autoUpdater.InstallNow();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            App app = (App)Application.Current;
            app.Shutdown();
        }
    }
}
