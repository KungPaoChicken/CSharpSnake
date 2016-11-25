using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GameWindow : Window {
        public GameWindow(Field field) {
            InitializeComponent();
            initializeGrid(field);
        }

        private void initializeGrid(Field field) {
            // Jagged array instead of multi-dimensional array is used for performance reasons
            // And similarity to our crappy Java code
            Rectangle[][] blocks = new Rectangle[field.width][];
            for (int i = 0; i < blocks.Length; i++) {
                blocks[i] = new Rectangle[field.height];
                for (int j = 0; j < blocks[i].Length; j++) {
                    blocks[i][j] = new Rectangle();
                    grid.Children.Add(blocks[i][j]);
                }
            }
            //blocks[i][j].Fill = new SolidColorBrush(Color.FromArgb(222, 0, 0, 0));
        }

        private void Window_KeyUp(object sender, KeyEventArgs e) {
            MessageBox.Show("You pressed " + e.Key.ToString());
        }
    }
}
