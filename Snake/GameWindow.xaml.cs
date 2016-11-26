using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Snake {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window {
        public GameWindow(Field field, int fps) {
            InitializeComponent();
            initializeGrid(field);
            initializeTimer(fps);
        }

        private Field field;
        private Rectangle[][] blocks;

        private void initializeGrid(Field field) {
            this.field = field;
            // Jagged array instead of multi-dimensional array is used for performance reasons
            // And similarity to our crappy Java code
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
                    Grid.SetRow(blocks[i][j], i);
                    Grid.SetColumn(blocks[i][j], j);
                    grid.Children.Add(blocks[i][j]);
                    if (i % 2 == 0 || j % 2 == 0) {
                        blocks[i][j].Fill = new SolidColorBrush(Color.FromArgb(222, 0, 0, 0));
                    } else {
                        blocks[i][j].Fill = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
                    }
                }
            }
        }

        private void initializeTimer(int fps) {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(render);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / fps);
            dispatcherTimer.Start();
        }

        private void render(object sender, EventArgs e) {
            for (int i = 0; i < field.width; i++) {
                for (int j = 0; j < field.height; j++) {
                        blocks[i][j].Fill = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
                }
            }
        }

        private void Window_KeyUp(object sender, KeyEventArgs e) {
            MessageBox.Show("You pressed " + e.Key.ToString());
        }
    }
}
