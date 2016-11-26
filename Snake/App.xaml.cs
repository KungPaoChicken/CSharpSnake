using System.Windows;
using System.Windows.Threading;
using System.Collections.Generic;

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
            List<Coordinate> body = new List<Coordinate> {new Coordinate(0, 0)};
            Snake snake = new Snake(body, Direction.RIGHT);
            Field field = new Field(50, 50, snake);
            GameWindow w = new GameWindow(field, FRAMES);
            w.Show();
        }

        private void main(object sender, StartupEventArgs e) {
            start();
        }
    }
}
