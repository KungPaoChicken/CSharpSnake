using System.Windows.Media;

namespace Snake {
    public class Command {
        public Command() {}
    }

    public class PauseCommand : Command {
        public PauseCommand() { }
    }

    public class DrawCommand : Command {
        public static readonly SolidColorBrush EMPTY = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        public static readonly SolidColorBrush SNAKE = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        public static readonly SolidColorBrush APPLE = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        public readonly SolidColorBrush type;
        public readonly Coordinate location;

        public DrawCommand(SolidColorBrush type, Coordinate location) {
            this.type = type;
            this.location = location;
        }
    }
}
