using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake {
    public partial class GameWindow : Window {
        private Rectangle[][] blocks;
        private Direction nextDirection;
        private Frame frame;
        private int sleepDuration;
        private System.Timers.Timer timer;

        public GameWindow(Field field, int fps) {
            InitializeComponent();
            initializeGrid(field);
            frame = new Frame(field);
            initializeTimer(fps);
            nextDirection = Direction.UP;
        }

        private void initializeGrid(Field field) {
            // Jagged array instead of multi-dimensional array is used for performance reasons
            // And similarity to our (crappy) Java code
            blocks = new Rectangle[field.width][];
            for (int i = 0; i < field.width; i++) {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            for (int i = 0; i < field.height; i++) {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int i = 0; i < field.width; i++) {
                blocks[i] = new Rectangle[field.height];
                for (int j = 0; j < field.height; j++) {
                    blocks[i][j] = new Rectangle();
                    blocks[i][j].Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
                    Grid.SetColumn(blocks[i][j], i);
                    Grid.SetRow(blocks[i][j], j);
                    grid.Children.Add(blocks[i][j]);
                }
            }
        }

        private void initializeTimer(int fps) {
            timer = new System.Timers.Timer();
            timer.Interval = 1000 / fps;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(show);
            timer.Enabled = true;
        }

        private void show(object sender, System.Timers.ElapsedEventArgs e) {
            App.Current.Dispatcher.BeginInvoke(
                DispatcherPriority.Render, 
                new Action(() => render(frame.nextFrame(nextDirection)))
                );
        }

        public void render(List<Command> commands) {
            foreach (Command c in commands) {
                if (c.GetType() == typeof(DrawCommand)) {
                    DrawCommand com = (DrawCommand)c;
                    blocks[((DrawCommand)c).location.x][((DrawCommand)c).location.y].Fill = ((DrawCommand)c).type;
                } else if (c.GetType() == typeof(PauseCommand)) { 
                    // CompositionTarget.Rendering -= render;
                    MessageBox.Show("Game over");
                }
            }
        }

        private void HandleKeyInput(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Up:
                case Key.Down:
                case Key.Left:
                case Key.Right:
                    Direction newDirection = Direction.fromKey(e.Key);
                    if (!nextDirection.isOpposite(newDirection)) {
                        nextDirection = newDirection;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
