using Microsoft.Win32;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using WpfApp3.Database;
using WpfApp3.Pages;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MediaPlayer mediaPlayer = new MediaPlayer();
        private SoundPlayer player;
        public MainWindow()
        {
           
            InitializeComponent();
           // mediaPlayer.Open(new Uri(@"/music/plamenev - русский не побеждён.mp3"));
            whitepage whitepage = new whitepage();
            Page1 page1= new Page1();
            player = new SoundPlayer();
            player.Stream = Properties.Resources.StalkerSOC; 
            
            player.PlayLooping();
            //MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder()
            //{
            //    Server = "cfif31.ru",
            //    Port = 3306,
            //    UserID = "ISPr22-43_NekrasovAI",
            //    Password = "ISPr22-43_NekrasovAI",
            //    CharacterSet = "utf8",
            //    Database = "ISPr22-43_NekrasovAI_02"
            //};
            //Trace.WriteLine(build.ConnectionString);
            //Server = cfif31.ru; Port = 3306; User ID = ISPr22 - 43_NekrasovAI; Password = ISPr22 - 43_NekrasovAI; Character Set = utf8; Database = ISPr22 - 43_NekrasovAI_02

            //            DispatcherTimer timer = new DispatcherTimer();
            //timer.Interval = TimeSpan.FromSeconds(1);
            //timer.Tick += timer_Tick;
            //timer.Start();
        }

        private void btPage1Click(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new Page1());
        }

        private void btPage2Click(object sender, RoutedEventArgs e)
        {
            FrNav.Navigate(new Page2());
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files|*.mp3|All files|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                mediaPlayer.Open(new Uri(openFileDialog.FileName));

            }
            mediaPlayer.Play();
           
        }

        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int SliderValue=(int)timelineSlider.Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            mediaPlayer.Position = ts;
        }

        private void Elemement_MediaOpened(object sender, RoutedEventArgs e)
        {
            timelineSlider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
        }
        //void timer_Tick(object sender, EventArgs e)
        //{
        //    if (mediaPlayer.Source != null)
        //        lblStatus.Content = String.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), Element_MediaOpened );
        //    else
        //        lblStatus.Content = "No file selected...";
        //}
        //private void Element_MediaOpened(object sender, EventArgs e)
        //{
        //    lblStatus.Content = mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss");
        //}
    }
}
