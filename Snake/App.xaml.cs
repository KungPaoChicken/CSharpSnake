using System.Windows;
using System.Windows.Threading;

namespace Snake {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {

        private static int WIDTH = 50;
        private static int HEIGHT = 50;
        private static int FRAMES = 30;
        private GameWindow w;

        private void HandleException(object sender, DispatcherUnhandledExceptionEventArgs e) {
            MessageBox.Show("Unhandled exception: " + e.Exception.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }

        private void start() {
            Snek snake = new Snek(WIDTH * HEIGHT, Direction.RIGHT);
            snake.add(new Coordinate(0, 0));
            Field field = new Field(WIDTH, HEIGHT, snake);
            w = new GameWindow(field, FRAMES);
            w.Show();
        }

        private void main(object sender, StartupEventArgs e) {
            start();
        }
    }
}
