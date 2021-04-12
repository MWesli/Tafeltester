using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Tafeltester.Properties;

namespace Tafeltester
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public partial class OptionsWindow : Window
    {
        public int Diff;
        public OptionsWindow()
        {
            InitializeComponent();
            usernamefield.Text = Settings.Default["Username"].ToString();
            ColorDiff();
        }

        public void ColorDiff()
        {
            string Difficulty = Settings.Default["Difficulty"].ToString();
            Diff = Int32.Parse(Difficulty);
            switch (Diff)
            {
                case 0:
                    easybutton.Foreground = new SolidColorBrush(Colors.Black);
                    normalbutton.Foreground = new SolidColorBrush(Colors.Gray);
                    hardbutton.Foreground = new SolidColorBrush(Colors.Gray);
                    Settings.Default["Difficulty"] = 0;
                    Settings.Default.Save();
                    break;
                case 1:
                    easybutton.Foreground = new SolidColorBrush(Colors.Gray);
                    normalbutton.Foreground = new SolidColorBrush(Colors.Black);
                    hardbutton.Foreground = new SolidColorBrush(Colors.Gray);
                    Settings.Default["Difficulty"] = 1;
                    Settings.Default.Save();
                    break;
                case 2:
                    easybutton.Foreground = new SolidColorBrush(Colors.Gray);
                    normalbutton.Foreground = new SolidColorBrush(Colors.Gray);
                    hardbutton.Foreground = new SolidColorBrush(Colors.Black);
                    Settings.Default["Difficulty"] = 2;
                    Settings.Default.Save();
                    break;
                default:
                    easybutton.Foreground = new SolidColorBrush(Colors.Black);
                    normalbutton.Foreground = new SolidColorBrush(Colors.Gray);
                    hardbutton.Foreground = new SolidColorBrush(Colors.Gray);
                    Settings.Default["Difficulty"] = 0;
                    Settings.Default.Save();
                    break;
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void SaveSettings(object sender, RoutedEventArgs e)
        {
            Settings.Default["Username"] = usernamefield.Text;
            Settings.Default.Save();
            ColorDiff();
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void easybutton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default["Difficulty"] = 0;
            Settings.Default.Save();
            ColorDiff();
        }

        private void normalbutton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default["Difficulty"] = 1;
            Settings.Default.Save();
            ColorDiff();
        }

        private void hardbutton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default["Difficulty"] = 2;
            Settings.Default.Save();
            ColorDiff();
        }
    }
}
