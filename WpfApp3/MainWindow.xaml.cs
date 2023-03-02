using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public MainWindow()
        {
           
            InitializeComponent();
           // mediaPlayer.Open(new Uri(@"/music/plamenev - русский не побеждён.mp3"));
            whitepage whitepage = new whitepage();
            Page1 page1= new Page1();
            /*MySqlConnectionStringBuilder build = new MySqlConnectionStringBuilder()
            { 
                Server = "cfif31.ru",
                Port = 3306,
                UserID = "ISPr22-43_NekrasovAI",
                Password = "ISPr22-43_NekrasovAI",
                CharacterSet = "utf8",
                Database = "ISPr22-43_NekrasovAI_02"
            };
            Trace.WriteLine(build.ConnectionString);
            Server=cfif31.ru;Port=3306;User ID=ISPr22-43_NekrasovAI;Password=ISPr22-43_NekrasovAI;Character Set=utf8;Database=ISPr22-43_NekrasovAI_02*/
            
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
            
            mediaPlayer.Play();
        }
    }
}
