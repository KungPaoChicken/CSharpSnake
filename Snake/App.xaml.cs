using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Snake
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        private void start() {
            GameWindow w = new GameWindow();
            w.Show();
        }

        private void main(object sender, StartupEventArgs e) {
            new GameWindow().Show();
        }
    }
}
