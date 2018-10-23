using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace DiagramDesigner
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            this.Startup += new StartupEventHandler(App_Startup);
        }

        void App_Startup(object sender, StartupEventArgs e)
        {
            var args = e.Args;
            this.InitializeComponent();
            MainView win = new MainView();
            if (args.Length > 0)
            {
                win.FileName = args[0];
            }
            this.MainWindow = win;
            win.Show();
        }
    }
}
