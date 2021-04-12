using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using Tafeltester.Properties;

namespace Tafeltester
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        public GameWindow()
        {
            InitializeComponent();
            GenerateSom();
        }
        public int Diff;
        public int awnser;
        public int score = 0;
        public string username = Settings.Default["Username"].ToString();

        private void GenerateSom()
        {
            nextButton.Visibility = Visibility.Visible;
            Random r = new Random();
            StringBuilder builder = new StringBuilder();

            int numOfOperand = r.Next(1, 3); // Number of operands.
            int randomNumber;

            string Difficulty = Settings.Default["Difficulty"].ToString();
            Diff = Int32.Parse(Difficulty);
            switch (Diff)
            {
                case 0:
                    randomNumber = r.Next(1, 100);
                    numOfOperand = r.Next(1, 3);
                    break;
                case 1:
                    randomNumber = r.Next(1, 200);
                    numOfOperand = r.Next(1, 4);
                    break;
                case 2:
                    randomNumber = r.Next(1, 1000);
                    numOfOperand = r.Next(1, 5);
                    break;
                default:
                    randomNumber = r.Next(1, 100);
                    numOfOperand = r.Next(1, 3);
                    break;
            }
            
            for (int i = 0; i < numOfOperand; i++)
            {
                switch (Diff)
                {
                    case 0:
                        randomNumber = r.Next(1, 100);
                        break;
                    case 1:
                        randomNumber = r.Next(1, 200);
                        break;
                    case 2:
                        randomNumber = r.Next(1, 1000);
                        break;
                    default:
                        randomNumber = r.Next(1, 100);
                        break;
                }
                builder.Append(randomNumber);

                int randomOperand = r.Next(1, 4);

                string operand = null;

                switch (randomOperand)
                {
                    case 1:
                        operand = "+";
                        break;
                    case 2:
                        operand = "-";
                        break;
                    case 3:
                        operand = "*";
                        break;
                    case 4:
                        operand = "/";
                        break;
                }
                builder.Append(operand);
            }
            randomNumber = r.Next(1, 100);
            builder.Append(randomNumber);
            DataTable dt = new DataTable(); 
            var v = dt.Compute(builder.ToString(), "").ToString();
            awnser = Int32.Parse(v);

            somLabel.Content = builder.ToString();
        }

        private void CheckAwnser()
        {
            int i;
            if (!int.TryParse(awnserbox.Text, out i))
            {

            }
            else
            {
                nextButton.Visibility = Visibility.Hidden;
                int userAwnser = Int32.Parse(awnserbox.Text);
                if (userAwnser == awnser)
                {
                    awnserbox.Background = new SolidColorBrush(Colors.Green);
                    awnserbox.Foreground = new SolidColorBrush(Colors.White);
                    awnserbox.Text = "Dat is goed!";
                    score++;
                    Settings.Default["CurrentScore"] = score;
                    Settings.Default.Save();
                    scorelabel.Content = "Score: " + score.ToString();
                    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                    timer.Start();
                    timer.Tick += (sender, args) =>
                    {
                        awnserbox.Text = "";
                        awnserbox.Background = null;
                        awnserbox.Foreground = new SolidColorBrush(Colors.Black);
                        GenerateSom();
                        timer.Stop();
                    };
                }
                else
                {
                    awnserbox.Background = new SolidColorBrush(Colors.Red);
                    awnserbox.Foreground = new SolidColorBrush(Colors.White);
                    awnserbox.Text = "Dat is fout! Het goeie antwoord was " + awnser.ToString();
                    Settings.Default["Highscore"] = score;
                    Settings.Default.Save();
                    nextButton.Visibility = Visibility.Hidden;
                    var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
                    timer.Start();
                    timer.Tick += (sender, args) =>
                    {
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Hide();
                        timer.Stop();
                    };
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (score < 30)
            {
                CheckAwnser();
            } else
            {
                somLabel.Content = "Goedzo! Je hebt het gehaald!";
                Settings.Default["Highscore"] = score;
                Settings.Default.Save();
                nextButton.Visibility = Visibility.Hidden;
                labels1.Visibility = Visibility.Hidden;
                labels2.Visibility = Visibility.Hidden;
                var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(5) };
                timer.Start();
                timer.Tick += (sender, args) =>
                {
                    MainWindow main = new MainWindow();
                    main.Show();
                    this.Close();
                };
            }
        }

        private void awnserbox_GotFocus(object sender, RoutedEventArgs e)
        {
            awnserbox.Text = null;
            var timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            timer.Start();
            timer.Tick += (sender, args) =>
            {
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();
            };
            timer.Stop();
        }
        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+ -");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
