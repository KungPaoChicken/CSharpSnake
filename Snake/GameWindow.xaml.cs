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
        private DispatcherTimer timer;
        private Renderer renderer;
        private Direction nextDirection;
        private Frame frame;

        public GameWindow(Field field, int fps) {
            InitializeComponent();
            initializeGrid(field);
            initializeTimer(fps);
            renderer = new Renderer(timer, blocks);
            nextDirection = Direction.UP;
            frame = new Frame(field);
            timer.Start();
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
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(render);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / fps);
        }

        private void render(object sender, EventArgs e) {
            renderer.render(frame.nextFrame(nextDirection));
        }

        private void pause() {
            timer.Stop();
        }

        private void unpause() {
            timer.Start();
        }

        private void draw(List<Coordinate> cs, SolidColorBrush colour) {
            foreach (Coordinate c in cs) {
                draw(c, colour);
            }
        }

        private void draw(Coordinate c, SolidColorBrush colour) {
            blocks[c.x][c.y].Fill = colour;
        }

        private void HandleKeyInput(object sender, KeyEventArgs e) {
            switch (e.Key) {
                case Key.Up:
                case Key.Down:
                case Key.Left:
                case Key.Right:
                    Direction newDirection = new Direction(e.Key);
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
