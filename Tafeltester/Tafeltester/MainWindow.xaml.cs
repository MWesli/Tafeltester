using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
using System.Windows.Threading;
using Tafeltester.Properties;


namespace Tafeltester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
    {
        public MainWindow()
        {
            InitializeComponent();
            usernamefield.Content = Settings.Default["Username"].ToString();
            var timeofday = "none";
            var uriSource = new Uri("https://wesli.dev/assets/images/ohoh.jpg");
            TimeSpan daystart = new TimeSpan(7, 0, 0);
            TimeSpan dayend = new TimeSpan(18, 0, 0);
            TimeSpan eveningstart = new TimeSpan(18, 0, 0);
            TimeSpan eveningend = new TimeSpan(19, 0, 0);
            TimeSpan nightstart = new TimeSpan(19, 0, 0);
            TimeSpan now = DateTime.Now.TimeOfDay;
            Random rnd = new Random();
            int rand = rnd.Next(1, 101);  // creates a number between 1 and 12
            if (rand > 1)
            {
                if ((now > daystart) && (now < dayend))
                {
                    timeofday = "Day";
                    uriSource = new Uri("https://wesli.dev/assets/images/DayMain.png");
                }
                else if ((now > eveningstart) && (now < eveningend))
                {
                    timeofday = "Evening";
                    uriSource = new Uri("https://wesli.dev/assets/images/EveningMain.png");
                }
                else if ((now > nightstart) && (now > daystart))
                {
                    timeofday = "Night";
                    uriSource = new Uri("https://wesli.dev/assets/images/NightMain.png");
                }
            } else
            {
                Background.Source = new BitmapImage(uriSource);
                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    SystemSounds.Beep.Play();
                    if ((now > daystart) && (now < dayend))
                    {
                        timeofday = "Day";
                        uriSource = new Uri("https://wesli.dev/assets/images/DayMain.png");
                    }
                    else if ((now > eveningstart) && (now < eveningend))
                    {
                        timeofday = "Evening";
                        uriSource = new Uri("https://wesli.dev/assets/images/EveningMain.png");
                    }
                    else if ((now > nightstart) && (now > daystart))
                    {
                        timeofday = "Night";
                        uriSource = new Uri("https://wesli.dev/assets/images/NightMain.png");
                    }
                    timer.Stop();
                    Background.Source = new BitmapImage(uriSource);
                };
            }
            Background.Source = new BitmapImage(uriSource);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            GameWindow game = new GameWindow();
            game.Show();
            this.Close();
        }

        private void usernamefield_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow options = new OptionsWindow();
            options.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OptionsWindow options = new OptionsWindow();
            options.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Highscores highscores = new Highscores();
            highscores.Show();
            this.Close();
        }
    }
}
