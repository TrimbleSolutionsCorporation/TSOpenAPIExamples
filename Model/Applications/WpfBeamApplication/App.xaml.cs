using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using Tekla.Structures.Model;

namespace WpfBeamApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Events events = new Tekla.Structures.Model.Events();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow();
            if(new Model().GetConnectionStatus())
            {
                events.TeklaStructuresExit += Events_ExitEvent;

                new System.Windows.Interop.WindowInteropHelper(window).Owner = Tekla.Structures.Dialog.MainWindow.Frame.Handle;
                window.Show();
            }
        }

        void Events_ExitEvent()
        {
            base.Shutdown();
        }


    }
}
