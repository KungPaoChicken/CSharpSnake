using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Snake
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            MessageBox.Show("Unhandled exception: " + e.Exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }

        private void start() {
            Field field = new Field(20, 20);
            GameWindow w = new GameWindow(field);
            w.Show();
        }

        private void main(object sender, StartupEventArgs e) {
            start();
        }
    }
}
