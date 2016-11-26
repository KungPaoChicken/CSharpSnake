﻿using System.Windows;
using System.Windows.Threading;

namespace Snake {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private static int FRAMES = 60;

        private void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            MessageBox.Show("Unhandled exception: " + e.Exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }

        private void start() {
            Field field = new Field(50, 50);
            GameWindow w = new GameWindow(field, FRAMES);
            w.Show();
        }

        private void main(object sender, StartupEventArgs e) {
            start();
        }
    }
}